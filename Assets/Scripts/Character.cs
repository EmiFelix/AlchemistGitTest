using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour
{

    [SerializeField] private CharacterData data;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move()
    {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(-moveHorizontal, 0, -moveVertical);
        movementDirection.Normalize();

        transform.Translate(movementDirection * data.speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, data.rotationSpeed * Time.deltaTime);

        }

        
    }

    
}
