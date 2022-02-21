using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossTransition : MonoBehaviour
{
    Animator animator;


    // Phase 2

    [SerializeField] private bool phase2transition;

    [SerializeField] private bool phase2start;

    [SerializeField] private bool flyFloatTransition;

    [SerializeField] private bool landTransition;


    //Fly Timer

    [SerializeField] private float flyTimer;
    [SerializeField] private double flying;

    // FlyFloat Timer

    [SerializeField] private float flyFloatTimer;
    [SerializeField] private double flyFloating;




    // Land Timer

    [SerializeField] private float landTimer;
    [SerializeField] private double landed;


    void Awake()
    {
        flyFloatTransition = false;
        landTransition = false;
        phase2start = false;




        
        flyTimer = 0;
        flyFloatTimer = 0;
        landTimer = 0;



        flying = 2.20;
        flyFloating = 2.20;
        landed = 2.20;

        phase2transition = true;
        animator = GetComponent<Animator>();
    }


    private void Fly()
    {


        if (phase2transition == true)
        {
            animator.Play("TakeOff");

            flyTimer += Time.deltaTime;

            if(flyTimer >= flying)
            {
                flyFloatTransition = true;

                flyTimer = 3;
            }

            
        }


    }

    private void FlyFloat()
    {
        if (flyFloatTransition == true)
        {
            animator.Play("FlyFloat");

            flyFloatTimer += Time.deltaTime;

            if(flyFloatTimer >= flyFloating)

            {
                landTransition = true;

                landTimer = 3;

            }

            
        }

        
    }

    private void Land()
    {
        



        if (landTransition == true)
        {
            animator.Play("Land");
            landTimer += Time.deltaTime;
        }

        if (landTimer >= landed)
        {
            landTimer = 3;

            phase2start = true;
        }
        
    }

    



    private void StartPhase2()
    {
        if (phase2start == true)
        {
            gameObject.GetComponent<DragonBossPhase2>().enabled = true;
        }
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Fly();
        FlyFloat();
        Land();
        StartPhase2();

    }
}
