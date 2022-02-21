using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarbarianController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private BarbarianFollowerController[] barbarianFollowers;

    public event Action<Vector3> OnMove;

    private void Awake()
    {
        for (int i = 0; i < barbarianFollowers.Length; i++)
        {
            OnMove += barbarianFollowers[i].Move;

            Debug.Log("Aqui usamos el 'OnMove' donde le pasamos la referencia de los 'BarbarianFollowerController' para que nos sigan");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    
    public void Move(in Vector3 dir)
    {
        if (dir.x == 0 && dir.z == 0)
            return;

        transform.position += speed * dir * Time.deltaTime;
       
        if (dir.x == 0 && dir.z == default)
            return;
        
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
       
    }

    
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var dir = new Vector3(-moveHorizontal, 0, -moveVertical);

        Move(dir);
        
        OnMove?.Invoke(dir);

    }
}
