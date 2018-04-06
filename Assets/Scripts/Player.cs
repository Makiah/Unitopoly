using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BoardLocation currentSpace;
    
    public IEnumerator MoveSpaces(int spaces)
    {
        bool movingForward = spaces > 0;
        spaces = Math.Abs(spaces);

        for (int i = 0; i < spaces; i++)
        {
            float timeForJump = 3;
            float startTime = Time.time;

            Vector3 startPosition = currentSpace.gameObject.transform.position;
            Vector3 endPosition = currentSpace.next.gameObject.transform.position;

            while (Time.time - startTime < timeForJump)
            {
                
            }
        }

        yield return null;
    }
}
