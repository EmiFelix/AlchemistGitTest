using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyList : MonoBehaviour
{

    public List<GameObject> enemies;
    


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("La cantidad de enemigos en este mapa es: " + enemies.Count);


        //Con este metodo, leemos la lista del ultimo al primero

        enemies.Reverse();

        foreach(var enemy in enemies)
        {
            Debug.Log(enemy.name);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
