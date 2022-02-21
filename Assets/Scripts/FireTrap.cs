using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    // Time Variables

    [SerializeField] private float bulletCooldown;
    [SerializeField] private float _counter;

    // Fireball props

    public GameObject flask;
    [SerializeField] private Transform flaskSpawn;
    


    private void LaunchFireball()
    {
        // Shoot 1 Bullet every X Seconds

        _counter += Time.deltaTime;

        if (_counter >= bulletCooldown)
        {
            Instantiate(flask, flaskSpawn.position, transform.rotation);
            _counter = 0;
        }




        


        
    }

    // Start is called before the first frame update
    void Start()
    {

        // Initialize counter
        _counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchFireball();
    }
}
