using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY1 : Enemies
{
    
    private void Start()
    {
        
    }

    void Update()
    {
        Stop();


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    
}
