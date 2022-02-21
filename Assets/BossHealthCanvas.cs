using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _bossHealth;



    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            
            _bossHealth.SetActive(true);

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            _bossHealth.SetActive(false);

        }
    }

}
