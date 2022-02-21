using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMProjectile : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private float speed;

    [SerializeField] Vector3 direction;


    public void MoveObject(Vector3 direction)
    {

        transform.Translate(speed * direction * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {

            collision.gameObject.GetComponent<DoctorMovement>().GoblinDamage(damage);
        }

            Destroy(gameObject);
    }

    void Update()
    {
        MoveObject(direction);
    }
}
