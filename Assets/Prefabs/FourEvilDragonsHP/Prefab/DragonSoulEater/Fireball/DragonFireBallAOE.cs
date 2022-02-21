using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireBallAOE : MonoBehaviour
{
    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;

    [SerializeField] private float _aoeDamage;

    private void DestroyAOE()
    {
        // Destroy Method

        bulletDestroyCounter += Time.deltaTime;

        if (bulletDestroyCounter >= bulletDestroyCD)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<DoctorMovement>().GoblinDamage(_aoeDamage);

        }
    }


    // Update is called once per frame
    void Update()
    {
        DestroyAOE();
    }
}