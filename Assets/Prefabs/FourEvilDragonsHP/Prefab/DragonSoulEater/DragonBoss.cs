using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonBoss : MonoBehaviour
{
    Animator animator;
    Animator animator2;

    // Arrow Spawn & CD

    [SerializeField] GameObject fireBall;
    [SerializeField] Transform fireBallSpawn;

    [SerializeField] private float fireBallCD;
    [SerializeField] private float fireBallCounter;


    [SerializeField] private GameObject _finnishCanvas;

    // Animation State Booleans

    bool isRunning;
    bool isRanged;
    bool isIdle;


    // Dragon Values
    

    [SerializeField] private EnemyType enemytype;

    [SerializeField] private float speed;


    [SerializeField] private Transform target;

    [SerializeField] private float minimumDistance;

    [SerializeField] private float minimumDistanceRanged;

    [SerializeField] private float speedToLook;

    [SerializeField] private float stopDistance;

    // HP

    private float currentHealth;

    [SerializeField] private float maxHealth;

    [SerializeField] private Image healthBarImage;

    // Phase 2

    [SerializeField] private float Stage2Threshold;




    private enum EnemyType
    {
        Chase,
        LookAtPlayer
    }
        
    private void Awake()
    {
        currentHealth = maxHealth;
        animator2 = GetComponent<Animator>();

        
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
            animator2.Play("Idle");
        }
    }

    private void StoppedWalking()
    {
        if (isRunning == false)
        {
            animator.SetBool("StoppedWalking", true);
        }

    }

    private void isWalking()
    {
        if (!isRunning == false)
        {
            animator.SetBool("isWalking", true);
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

            animator2.Play("Walk");
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

    private void FireBallCD()
    {
        fireBallCounter += Time.deltaTime;

        if (fireBallCounter >= fireBallCD)
        {
            animator2.Play("FireballShoot");
            Instantiate(fireBall, fireBallSpawn.position, fireBallSpawn.rotation);

            fireBallCounter = 0;

            animator.SetBool("Attacked", true);

        }
    }


    // GET DAMAGE
    public void DragonGetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        var healthPercentage = currentHealth / maxHealth;

        healthBarImage.fillAmount = healthPercentage;


        if (currentHealth == 0)
        {
            Destroy(gameObject);

            _finnishCanvas.SetActive(true);

        }
           
    }

    private void Phase2()
    {
        if(currentHealth < Stage2Threshold)
        {
            fireBallCD = 2;            

        }

        

    }

    private void Ranged()
    {
        // FireBall Spawn
        if (isRanged == true)
        {
            FireBallCD();
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
        animator = GetComponent<Animator>();
        fireBallCounter = 0;

        
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

    


    // Update is called once per frame
    void Update()
    {
        Idle();
        Ranged();
        isWalking();
        StoppedWalking();
        SelectEnemy(enemytype);
        Phase2();

        
    }
    
}