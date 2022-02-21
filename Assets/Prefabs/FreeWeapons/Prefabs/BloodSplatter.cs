using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;

    private void DestroyBlood()
    {
        // Destroy Method

        bulletDestroyCounter += Time.deltaTime;

        if (bulletDestroyCounter >= bulletDestroyCD)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletDestroyCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBlood();
    }
}
