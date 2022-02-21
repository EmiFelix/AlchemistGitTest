using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : MonoBehaviour
{

    public ItemDrop thisLoot;

    [SerializeField] Transform _dropPosition;


    Animator animator;


    // Arrow Spawn & CD

    [SerializeField] GameObject goblinArrow;
    [SerializeField] Transform goblinArrowSpawn;

    [SerializeField] private float arrowCD;
    [SerializeField] private float arrowCooldownCounter;


    // State Booleans
    bool isRunning;
    bool isRanged;
    bool isIdle;


    // HP Imp

    [SerializeField] private float maxHealth;

    private float currentHealth;

    private enum EnemyType
    {
        Chase,
        LookAtPlayer
    }

    [SerializeField] private EnemyType enemytype;

    [SerializeField] private float speed;


    [SerializeField] private Transform target;

    [SerializeField] private float minimumDistance;

    [SerializeField] private float minimumDistanceRanged;

    [SerializeField] private float speedToLook;

    [SerializeField] private float stopDistance;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    private void Idle()
    {
        if (!isRunning && !isRanged)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }

        if (isIdle == true)
        {
            animator.Play("Idle");
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

            animator.Play("OrcWalk");
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

    private void ArrowCD()
    {
        arrowCooldownCounter += Time.deltaTime;

        if (arrowCooldownCounter >= arrowCD)
        {

            Instantiate(goblinArrow, goblinArrowSpawn.position, goblinArrowSpawn.rotation);

            arrowCooldownCounter = 0;

            Destroy(gameObject);
        }
    }


    private void Ranged()
    {
        // Arrow Spawn
        if (isRanged == true)
        {
            ArrowCD();
        }



        //Ranged Attack

        var vectorDistance = target.position - transform.position;

        var direction = vectorDistance.normalized;

        transform.forward = direction;

        if (vectorDistance.magnitude < minimumDistanceRanged)
        {
            animator.Play("AOE");
            isRanged = true;

        }
        else
        {
            isRanged = false;
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
        arrowCooldownCounter = 0;
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

    public void ImpDamage(float damageAmount)
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
        if (thisLoot != null)
        {
            GameObject current = thisLoot.LootHP();

            if (current != null)
            {
                Instantiate(current.gameObject, _dropPosition.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
        Ranged();
        SelectEnemy(enemytype);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

        }

    }
}