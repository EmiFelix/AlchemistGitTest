using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    
    private void Start()
    {
        GameEvents.current.OnWallTriggerEnter += OnWallOpen;
        GameEvents.current.OnWallTriggerExit += OnWallExit;
    }

    private void OnWallOpen()
    {
        LeanTween.moveLocalY(gameObject, 64.5f, 1f).setEaseOutQuad();

    }
    private void OnWallExit()
    {
        LeanTween.moveLocalY(gameObject, 61.6f, 1f).setEaseInQuad();


    }


}
