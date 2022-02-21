using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutOfServicePanel : MonoBehaviour
{

    [SerializeField] private GameObject OutOfService;


    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        OutOfService.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        OutOfService.SetActive(false);
    }

}
