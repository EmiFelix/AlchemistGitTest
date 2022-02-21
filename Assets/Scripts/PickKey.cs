using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{

    [SerializeField] private Component _doorCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay()
    {
        _doorCollider.GetComponent<BoxCollider>().enabled = true;

    }
}
