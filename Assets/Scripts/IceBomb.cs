using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBomb : MonoBehaviour
{
    [SerializeField] private float speed;

    public int damage;

    [SerializeField] private Vector3 direction;

    // IceAOE

    [SerializeField] private GameObject iceAOE;
    [SerializeField] private Transform iceAOEspawn;


    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;


    //Item drop

    private ItemDrop getItem;


    private void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;

        GameManager.instance.ObtainIceDamage(this);

        //getItem = GetComponent<ItemDrop>();

    }


    private void DestroyIce()
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

        DestroyIce();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(iceAOE, iceAOEspawn.position, transform.rotation);

        if (collision.transform.tag == "Enemy")
        {

            collision.gameObject.GetComponent<GoblinBlue>().GoblinGetDamage(damage);

   
        }

        if (collision.transform.tag == "Boss")
        {

            collision.gameObject.GetComponent<DragonBoss>().DragonGetDamage(damage);

        }

        Destroy(gameObject);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            other.gameObject.GetComponent<GoblinRed>().GoblinRedGetDamage(damage);
        }
    }

    // OverlapSphere AOE Check

    /* private void CheckForDestructibles()
     {
         Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
         foreach(Collider c in colliders)
         {
             if (c.GetComponent<ENEMY3>())
             {
                 c.GetComponent<ENEMY3>(); //.StartCoroutine.ExplosionSequence > La idea es aca hacer una Coroutine en el mob para que empiece a tomar daño o resolverlo de otro modo /watch?v=ode1-TwzNT0.
             }
         }
     }
     */
}
