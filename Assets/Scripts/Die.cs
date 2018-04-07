using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour 
{
    public int GetDieValue()
    {
        Transform faceWithHighestY = transform.GetChild(0);

        for (int i = 1; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).position.y > faceWithHighestY.position.y)
            {
                faceWithHighestY = transform.GetChild(i);
            }
        }

        return Int32.Parse(faceWithHighestY.gameObject.name);
    }
}
