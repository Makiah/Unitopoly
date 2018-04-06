using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BoardLocation currentSpace;

    void Start()
    {
        StartCoroutine(MoveSpaces(8));
    }
    
    public IEnumerator MoveSpaces(int spaces)
    {   
        bool movingForward = spaces > 0;
        spaces = Math.Abs(spaces);

        for (int i = 0; i < spaces; i++)
        {
            BoardLocation targetSpace = movingForward ? currentSpace.next : currentSpace.preceding;
            
            currentSpace.PassBy(this);
            
            float timeForJump = .75f;
            float startTime = Time.time;

            Vector3 startPosition = currentSpace.gameObject.transform.position;
            Vector3 endPosition = targetSpace.gameObject.transform.position;

            Vector3 desiredDisplacement = endPosition - startPosition;
            desiredDisplacement.y = 0;

            float progressionCoefficient = 0;
            while (progressionCoefficient < 1)
            {
                progressionCoefficient = (Time.time - startTime) / timeForJump;
                Vector3 newPosition = startPosition + desiredDisplacement * progressionCoefficient;
                newPosition.y = (float)(-2 * Math.Pow(progressionCoefficient - 0.5, 2) + 0.5);

                transform.position = newPosition;

                yield return null;
            }
            
            // Onto the next space!
            currentSpace = targetSpace;
            transform.position = currentSpace.transform.position;
        }
        
        // Tell the space we ended on that we landed on it.  
        currentSpace.LandOn(this);

        yield return null;
    }
}
