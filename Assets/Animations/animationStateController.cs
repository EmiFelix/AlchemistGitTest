using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isLeftStrafingHash;
    int isRightStrafingHash;
    int isBackwardsHash;


    //hit

    // int isKickingHash;
    // int isMeleeHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isLeftStrafingHash = Animator.StringToHash("isLeftStrafing");
        isRightStrafingHash = Animator.StringToHash("isRightStrafing");
        isBackwardsHash = Animator.StringToHash("isBackwards");


        //hit

        // isKickingHash = Animator.StringToHash("isKicking");
        // isMeleeHash = Animator.StringToHash("isMelee");

        
    }


    private void IsWalkingAnim()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isLeftStrafing = animator.GetBool(isLeftStrafingHash);
        bool isRightStrafing = animator.GetBool(isRightStrafingHash);
        bool isBackwards = animator.GetBool(isBackwardsHash);

        // hit
        // bool isKicking = animator.GetBool(isKickingHash);
        // bool isMelee = animator.GetBool(isMeleeHash);


        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backwardsPressed = Input.GetKey("s");

        // hit


        // bool kickPressed = Input.GetKey("f");
        // bool hitPressed = Input.GetMouseButton(0);



        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);

        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isLeftStrafing && leftPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isLeftStrafing && !leftPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRightStrafing && rightPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isRightStrafing && !rightPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isBackwards && backwardsPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isBackwards && !backwardsPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // hit

        /*
        if (!isKicking && kickPressed)
        {
            animator.SetBool(isKickingHash, true);
        }

        if (isKicking && !kickPressed)
        {
            animator.SetBool(isKickingHash, false);
        }

        if (!isMelee && hitPressed)
        {
            animator.SetBool(isMeleeHash, true);
        }

        if (isMelee && !hitPressed)
        {
            animator.SetBool(isMeleeHash, false);
        }
        */

        
    }





    // Update is called once per frame
    void Update()
    {
        IsWalkingAnim();

        
    }
}
