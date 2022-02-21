using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY2 : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float speedToLook;


    private void Awake()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
