using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string playerName;
    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    private bool isAI = false;
    public void SetIsAI(bool isAI)
    {
        this.isAI = isAI;
    }

    private BalanceTracker balanceTracker;
    public void SetBalanceTracker(BalanceTracker balanceTracker)
    {
        this.balanceTracker = balanceTracker;
        
        this.balanceTracker.UpdateName(playerName);
    }
    
    // Money
    private int accountBalance = 1500;

    public void AdjustBalanceBy(int balance)
    {
        accountBalance += balance;
        balanceTracker.UpdateBalance(accountBalance);
    }

    public int GetBalance()
    {
        return accountBalance;
    }
    
    private BoardLocation currentSpace;

    public void Initialize()
    {
        currentSpace = PassGo.instance;
    }
    
    public IEnumerator MoveSpaces(int spaces)
    {   
        bool movingForward = spaces > 0;
        spaces = Math.Abs(spaces);

        for (int i = 0; i < spaces; i++)
        {
            BoardLocation targetSpace = movingForward ? currentSpace.next : currentSpace.preceding;
            
            if (targetSpace == null)
                throw new Exception("What the actual fucking piece of goddamn shit");
            
            currentSpace.PassBy(this);
            
            float timeForJump = .9f * (Mathf.Sqrt((i * 1.0f) / spaces + .8f) - .35f);
            float startTime = Time.time;

            Vector3 startPosition = currentSpace.gameObject.transform.position;
            Vector3 endPosition = targetSpace.gameObject.transform.position;

            Vector3 desiredDisplacement = endPosition - startPosition;
            desiredDisplacement.y = 0;

            float progressionCoefficient = 0;
            while (progressionCoefficient <= .98f)
            {
                progressionCoefficient = (Time.time - startTime) / timeForJump;
                
                Vector3 newPosition = startPosition + desiredDisplacement * progressionCoefficient;
                newPosition.y = -1 * Mathf.Pow(progressionCoefficient - 0.5f, 2) + 0.25f;

                transform.position = newPosition;

                yield return null;
            }
            
            // Onto the next space!
            currentSpace = targetSpace;
            transform.position = currentSpace.transform.position;
            
            // Rotate if we're on a corner space.  
            if (currentSpace is PassGo || currentSpace is GoToJail || currentSpace is InJail ||
                currentSpace is FreeParking)
            {
                progressionCoefficient = 0;
                startTime = Time.time;
                float timeForRotate = 1f;
                float startAngle = transform.eulerAngles.y;
                
                while (progressionCoefficient <= .98f)
                {
                    progressionCoefficient = (Time.time - startTime) / timeForRotate;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, startAngle + 90 * progressionCoefficient, transform.eulerAngles.z);

                    yield return null;
                }
                
                // Finalize rotation.  
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, startAngle + 90, transform.eulerAngles.z);
            }
        }
        
        // Tell the space we ended on that we landed on it.  
        yield return currentSpace.LandOn(this);
    }
}
