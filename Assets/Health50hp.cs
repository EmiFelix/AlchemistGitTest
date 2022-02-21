using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health50hp : MonoBehaviour
{
    private float _healthC = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<DoctorMovement>().HealDamage(_healthC);

            Destroy(gameObject);
        }
    }
}
