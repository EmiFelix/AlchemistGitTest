using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMonster : MonoBehaviour
{
    // Arrow Spawn & CD

    [SerializeField] GameObject goblinArrow;
    [SerializeField] Transform goblinArrowSpawn;

    [SerializeField] private float arrowCD;
    [SerializeField] private float arrowCooldownCounter;


    // State Booleans
    bool isRunning;
    bool isRanged;
    bool isIdle;

    Animation animation;


    // HP StoneMonster

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
        animation = GetComponent<Animation>();

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
            animation.Play("Anim_Idle");
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

            animation.Play("Anim_Run");
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
            animation.Play("Anim_Attack");
            animation.PlayQueued("Anim_Run", QueueMode.CompleteOthers);
            Instantiate(goblinArrow, goblinArrowSpawn.position, goblinArrowSpawn.rotation);
            
            arrowCooldownCounter = 0;

            

        }
    }

    private void AttackAnimCD()
    {

    }


    private void Ranged()
    {
        // Arrow Spawn
        if (isRanged == true)
        {
            AttackAnimCD();
            ArrowCD();
        }

        //Ranged Attack

        var vectorDistance = target.position - transform.position;

        var direction = vectorDistance.normalized;

        transform.forward = direction;

        if (vectorDistance.magnitude < minimumDistanceRanged)
        {
            
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

    public void StoneMDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
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