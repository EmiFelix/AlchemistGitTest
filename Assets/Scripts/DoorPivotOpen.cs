using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPivotOpen : MonoBehaviour
{

    [SerializeField] private AudioSource _openDoorSound;

    [SerializeField] private AudioSource _closeDoorSound;

    //Door Animations

    [SerializeField] private Animator _door;

    [SerializeField] private GameObject _doorCanvas;

    bool doorClosed = true;



    private void Awake()
    {
       
    }

    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider collider)
    {
        if(doorClosed)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _openDoorSound.Play();

                _door.Play("DoorOpen", 0, 0.0f);



               doorClosed = false;
                
            }
                
        }

        _doorCanvas.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (!doorClosed)
        {
            _door.Play("DoorClosed", 0, 0.0f);

            _closeDoorSound.Play();

            doorClosed = true;
            
        }

        _doorCanvas.SetActive(false);
    }
}