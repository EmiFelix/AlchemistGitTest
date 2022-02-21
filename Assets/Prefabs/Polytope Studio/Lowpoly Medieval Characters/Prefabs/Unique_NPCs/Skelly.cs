using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : MonoBehaviour
{

    public ItemDrop thisLoot;

    [SerializeField] Transform _dropPosition;

    Animator animator;

    // State Bools
    bool isRunning;
    bool isMelee;
    bool isIdle;


    private enum EnemyType
    {
        Chase,
        LookAtPlayer
    }

    [SerializeField] private EnemyType enemytype;

    [SerializeField] private float speed;


    [SerializeField] private Transform target;

    [SerializeField] private float minimumDistance;

    [SerializeField] private float minimumDistanceMelee;

    [SerializeField] private float speedToLook;

    [SerializeField] private float stopDistance;


    // HP Imp

    [SerializeField] private float maxHealth;

    private float currentHealth;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;

    }

    private void Idle()
    {
        if (!isRunning && !isMelee)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }

        if (isIdle == true)
        {
            animator.Play("ZombieIdle");
        }
    }


    private void Chase()
    {
        var vectorDistance = target.position - transform.position;

        var direction = vectorDistance.normalized;


        transform.forward = direction;

        if (vectorDistance.magnitude < minimumDistance)
        {

            transform.position += speed * Time.deltaTime * direction;

            animator.Play("ZombieWalk");
            isRunning = true;

        }
        else
        {
            isRunning = false;
        }

    }



    private void Stop()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);



        if (dist > stopDistance)
        {
            Chase();

        }
    }


    private void Melee()
    {
        // Melee
        if (isMelee == true)
        {
            animator.Play("ZombieAttack");
        }



        //Melee Attack Bools

        var vectorDistance = target.position - transform.position;

        var direction = vectorDistance.normalized;

        transform.forward = direction;

        if (vectorDistance.magnitude < minimumDistanceMelee)
        {

            isMelee = true;

        }
        else
        {
            isMelee = false;
        }


    }

    private void LookAtPlayer()
    {

        Quaternion newRotation = Quaternion.LookRotation((target.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    private void SelectEnemy(EnemyType enemyType)
    {
        switch (enemytype)
        {
            case EnemyType.Chase:
                Stop();
                break;

            case EnemyType.LookAtPlayer:
                LookAtPlayer();
                break;
        }
    }

    public void SkullyDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);

            MakeLoot();
        }
    }


    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            GameObject current = thisLoot.LootHP();

            if(current != null)
            {
                Instantiate(current.gameObject, _dropPosition.position, Quaternion.identity);
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        Idle();
        Melee();
        SelectEnemy(enemytype);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

        }
    }
}
