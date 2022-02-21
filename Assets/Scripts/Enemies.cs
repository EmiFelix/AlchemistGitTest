using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [SerializeField] private EnemiesData data;

    [SerializeField] private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Chase()
    {
        var vectorDistance = target.position - transform.position;

        var direction = vectorDistance.normalized;


        transform.forward = direction;

        if (vectorDistance.magnitude < data.minimumDistance)
        {

            transform.position += data.speed * Time.deltaTime * direction;
        }

    }

    public void Stop()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist > data.stopDistance)
        {
            Chase();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
