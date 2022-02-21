using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAura : MonoBehaviour
{
    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;

    // Health cuantity

    [SerializeField] private float _healthC;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;
    }

    // Destroy Method

    private void DestroyHealAura()
    {
        // Destroy Method

        bulletDestroyCounter += Time.deltaTime;

        if (bulletDestroyCounter >= bulletDestroyCD)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<DoctorMovement>().HealDamage(_healthC);
        }
    }


    // Update is called once per frame
    void Update()
    {
        DestroyHealAura();
    }
}
