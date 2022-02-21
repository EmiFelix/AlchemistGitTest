using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CubeController : MonoBehaviour
{
    

    public event Action<float> OnMove;
    public event Action OnJump;
    public event Action<float> OnRotate;
    

    public UnityEvent<float> OnMoveUnity;
    public UnityEvent OnJumpUnity;
    public UnityEvent<float> OnRotateUnity;


    private float horizontal;
    private float vertical;

    
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Vertical");
        vertical = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //OnJump?.Invoke();
            OnJumpUnity?.Invoke();

        }

        if(horizontal != 0)
        {
            //OnMove?.Invoke(-horizontal);
            OnMoveUnity?.Invoke(-horizontal);

        }

        if (vertical != 0)
        {
            //OnRotate?.Invoke(vertical);
            OnRotateUnity?.Invoke(vertical);

        }
    }

}
