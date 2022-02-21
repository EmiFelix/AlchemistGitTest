using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraControl : MonoBehaviour
{

    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;



    // Start is called before the first frame update
    void Start()
    {
    }

    private void SwitchCamera()
    {

        if (Input.GetKeyDown("1"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);

            //camera1.enabled = true;
            //camera2.enabled = false;
        }

        if (Input.GetKeyDown("2"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);


            //camera1.enabled = false;
            //camera2.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        SwitchCamera();


    }
}
