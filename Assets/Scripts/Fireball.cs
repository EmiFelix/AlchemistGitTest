using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Vector3 direction;

    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;

    private void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;
    }


    private void DestroyFireball()
    {
        // Destroy Method

        bulletDestroyCounter += Time.deltaTime;

        if (bulletDestroyCounter >= bulletDestroyCD)
        {
            Destroy(gameObject);
        }

    }

    public void MoveObject(Vector3 direction)
    {

        transform.Translate(speed * direction * Time.deltaTime);
    }

    void Update()
    {
        MoveObject(direction);

        DestroyFireball();
    }
}
