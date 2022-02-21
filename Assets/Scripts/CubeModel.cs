using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeModel : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rigidBody;
    [SerializeField] private float jumpForce;



    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();   
    }


    public void SubToEvents(CubeController controller)
    {
        controller.OnMove += OnMoveHandler;
        controller.OnJump += OnJumpHandler;
        controller.OnRotate += OnRotateHandler;
    }


    public void OnMoveHandler(float movementDirection)
    {
        transform.position += transform.forward * movementDirection * moveSpeed * Time.deltaTime;

        Debug.Log("Agui se llamó a 'OnMove'. Recibió CubeModel");
    }

    public void OnJumpHandler()
    {
        rigidBody.AddForce(Vector3.up * jumpForce);

        Debug.Log("Agui se llamó a 'OnJump'. Recibió CubeModel");
    }

    public void OnRotateHandler(float rotationDirection)
    {
        var rotation = new Vector3(0, rotationDirection * rotationSpeed * Time.deltaTime);

        transform.Rotate(rotation);

        Debug.Log("Agui se llamó a 'OnRotate'. Recibió CubeModel");
    }
}
