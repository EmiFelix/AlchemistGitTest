using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskAOE : MonoBehaviour
{
    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;

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

    // Update is called once per frame
    void Update()
    {
        DestroyAOE();
    }
}
