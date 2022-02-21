using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;


    private void Awake()
    {
        current = this;
    }

    public event Action OnWallTriggerEnter;

    public void WallTriggerEnter()
    {
        if(OnWallTriggerEnter != null)
        {
            OnWallTriggerEnter();
        }

        Debug.Log("Aqui llamamos al evento del 'WallControler' para levantar la puerta");
    }

    public event Action OnWallTriggerExit;

    public void WallTriggerExit()
    {
        if (OnWallTriggerExit != null)
        {
            OnWallTriggerExit();
        }

        Debug.Log("Aqui llamamos al evento del 'WallControler' para bajar la puerta");
    }

}
