using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieRoller : MonoBehaviour
{
    public static DieRoller instance;

    private Vector3[] initialDiePositions;

    [SerializeField] private bool testRepeatedDieRolls = false;
    
    void Awake()
    {
        instance = this;
        
        initialDiePositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            initialDiePositions[i] = transform.GetChild(i).transform.position;
    }

    void Start()
    {
        if (testRepeatedDieRolls)
            StartCoroutine(TestDieRollsRepeated());
    }

    private IEnumerator TestDieRollsRepeated()
    {
        for (int i = 0; i < 16; i++)
        {
            yield return RollDie();
        }
    }

    public int GetDieRollValue()
    {
        return 0;
    }

    public void ResetDie()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).transform.position = initialDiePositions[i];
    }

    public void RandomizeDieRotations()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).transform.rotation = UnityEngine.Random.rotation;
    }

    public IEnumerator RollDie()
    {
        ResetDie();
        RandomizeDieRotations();

        yield return new WaitForSeconds(2);
        
        while (true)
        {
            bool foundMovingDie = false;
            
            Rigidbody[] dieMovements = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody dieMovement in dieMovements)
            {
                if (!dieMovement.IsSleeping())//(dieMovement.velocity.magnitude > .1f)
                {
                    foundMovingDie = true;
                    break;
                }
            }

            yield return null;

            if (!foundMovingDie)
                break;
        }

        string dieVals = "";
        Die[] dies = gameObject.GetComponentsInChildren<Die>();
        
        foreach (Die die in dies)
        {
            dieVals = dieVals + " " + die.GetDieValue();
        }
        
        Debug.Log("Got" + dieVals);
    }
}
