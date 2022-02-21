using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWand : MonoBehaviour
{
    [SerializeField] private GameObject _pickUpWand;

    [SerializeField] private GameObject _handWand;

    [SerializeField] private GameObject _pickUpPanel;

    


    private void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        _pickUpPanel.SetActive(true);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            _pickUpWand.SetActive(false);

            _handWand.SetActive(true);

            _pickUpPanel.SetActive(false);

            other.gameObject.GetComponent<WandPick>().enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _pickUpPanel.SetActive(false);

    }


}
