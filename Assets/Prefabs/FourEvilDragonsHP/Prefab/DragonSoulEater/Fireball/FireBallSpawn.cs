using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawn : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speedToLook;

    private void LookAtPlayer()
    {

        Quaternion newRotation = Quaternion.LookRotation((target.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }
}
