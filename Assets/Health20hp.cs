using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health20hp : MonoBehaviour
{
    private float _healthC = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<DoctorMovement>().HealDamage(_healthC);

            Destroy(gameObject);
        }
    }
}
