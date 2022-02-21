using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolArray : MonoBehaviour
{

   [SerializeField] private Transform[] positionPatrol;

    int current;
   
    private float dis;

    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        transform.LookAt(positionPatrol[current].position);
    }


    // Aqui le damos movimiento
    private void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    
    // Aqui vamos cambiando el punto de patrullaje y hacemos que al hacerlo, mire al proximo punto.
    private void IncreasedCurrent()
    {
        current++;
        if(current >= positionPatrol.Length)
        {
            current = 0;
        }
        
        transform.LookAt(positionPatrol[current].position);
        
    }


    // Update is called once per frame
    void Update()
    {

        // Esto es para que al estar a 1f de distancia, cambie el recorrido

        dis = Vector3.Distance(transform.position, positionPatrol[current].position);

        if (dis < 1f)
        {
            IncreasedCurrent();
        }
        
        Patrol();
        
    }


}
