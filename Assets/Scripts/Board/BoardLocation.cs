using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardLocation : MonoBehaviour
{
    [HideInInspector] public BoardLocation preceding, next;
    
    private void Awake()
    {   
        int currentSpace = Int32.Parse(gameObject.name);
        
        next = currentSpace < 39 ? 
            gameObject.transform.parent.Find((currentSpace + 1).ToString()).GetComponent<BoardLocation>() : 
            gameObject.transform.parent.Find("0").GetComponent<BoardLocation>();
        
        preceding = currentSpace > 0 ? 
            gameObject.transform.parent.Find((currentSpace - 1).ToString()).GetComponent<BoardLocation>() : 
            gameObject.transform.parent.Find("39").GetComponent<BoardLocation>();
        
        AdditionalInit();
    }

    // DO NOT OVERRIDE AWAKE OR BAD THINGS HAPPEN >:(
    protected virtual void AdditionalInit() {}
    
    // Player instances call this when they pass by this space.  
    public abstract void PassBy(Player player);

    protected IEnumerator LerpCameraViewToThisLocation()
    {
        // Show the player a close up of the property they landed on.  
        yield return CameraController.instance.LerpToCameraViewTargets(transform.position + new Vector3(0, 3, 0),
            transform.eulerAngles, 1.2f);
    }

    protected IEnumerator LerpCameraViewBackToMainBoardView()
    {
        yield return CameraController.instance.LerpToViewBoardTarget(1f);
    }

    public abstract IEnumerator LandOn(Player player);
}
