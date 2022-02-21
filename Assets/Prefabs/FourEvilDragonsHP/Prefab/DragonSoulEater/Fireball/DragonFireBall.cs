using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireBall : MonoBehaviour
{
    [SerializeField] private float speed;

    public int damage;

    [SerializeField] private Vector3 direction;

    // FireAOE

    [SerializeField] private GameObject fireAOE;
    [SerializeField] private Transform fireAOESpawn;


    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;


    //Item drop

    //private ItemDrop getItem;


    private void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;

        // GameManager.instance.ObtainIceDamage(this);

        // getItem = GetComponent<ItemDrop>();

    }


    private void DestroyFire()
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

        DestroyFire();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(fireAOE, fireAOESpawn.position, fireAOESpawn.rotation);
        Destroy(gameObject);

        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<DoctorMovement>().GoblinDamage(damage);

        }
    }
}

