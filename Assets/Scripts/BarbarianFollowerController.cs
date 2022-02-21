using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianFollowerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

 
    public void Move(Vector3 dir) 
    {
        if (dir.x == 0 && dir.z == 0)
            return;

        transform.position += speed * transform.forward * Time.deltaTime;
        
        if (dir.x == 0 && dir.z == default)
            return;

        Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

    }

}
