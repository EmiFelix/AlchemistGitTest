using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{

    [SerializeField] private float speed;

    public int damage;

    [SerializeField] private Vector3 direction;

    // FlaskAOE

    [SerializeField] private GameObject flaskAOE;
    [SerializeField] private Transform AOEspawn;


    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;


    //Item drop

    private ItemDrop getItem;

    private void Awake()
    {
        
    }
    private void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;

        GameManager.instance.ObtainFlaskDamage(this);

        //getItem = GetComponent<ItemDrop>();


    }


    private void DestroyFlask()
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

        DestroyFlask();

    }
    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(flaskAOE, AOEspawn.position, transform.rotation);

        if(collision.transform.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<GoblinBlue>().GoblinGetDamage(damage);

        }

        if (collision.transform.tag == "Boss")
        {

            collision.gameObject.GetComponent<DragonBoss>().DragonGetDamage(damage);

        }

        if (collision.transform.tag == "ImpEnemy")
        {

            collision.gameObject.GetComponent<Imp>().ImpDamage(damage);

        }

        if (collision.transform.tag == "SkullyEnemy")
        {

            collision.gameObject.GetComponent<Skelly>().SkullyDamage(damage);

        }

        if (collision.transform.tag == "StoneMEnemy")
        {

            collision.gameObject.GetComponent<StoneMonster>().StoneMDamage(damage);

        }

        Destroy(gameObject);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
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
