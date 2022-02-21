using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public GameObject flask;

    private Flask flaskDamage;


    private void Awake()
    {
        flaskDamage = flask.GetComponent<Flask>();
    }

    // Modify Damage flask on pick up item
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            flaskDamage.damage *= 2;
        }
    }


}
