using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArrow : MonoBehaviour
{
    [SerializeField] private float speed;

    public int damage;
    
    [SerializeField] private Vector3 direction;

    // Destroy Variables

    [SerializeField] private float bulletDestroyCD;
    [SerializeField] private float bulletDestroyCounter;

    // Blood Hit

    [SerializeField] private GameObject bloodSplatter;
    [SerializeField] private Transform bloodSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Counter

        bulletDestroyCounter = 0;

    }



    private void DestroyArrow()
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

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            Instantiate(bloodSplatter, bloodSpawn.position, bloodSpawn.rotation);
        }

        Destroy(gameObject);

        collision.gameObject.GetComponent<DoctorMovement>().GoblinDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyArrow();
        MoveObject(direction);

    }
}