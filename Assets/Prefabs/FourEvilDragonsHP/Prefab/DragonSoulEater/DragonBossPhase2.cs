using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossPhase2 : MonoBehaviour
{

    


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

    private void Awake()
    {

        animator = GetComponent<Animator>();
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

                animator.Play("Run");
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
                animator.Play("TailAttack");
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
