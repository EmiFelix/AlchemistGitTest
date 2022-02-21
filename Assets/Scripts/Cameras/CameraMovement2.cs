using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    private Vector3 initialDifference;

    [SerializeField] private Transform followTarget;



    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private LayerMask otherLayerMask;

    [SerializeField] private Transform wallsReEnable;

    [SerializeField] private float maxDistance;


    public void RaycastDart()
    {
        RaycastHit hit;

        var collideSomething = Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, wallLayerMask);



        if (collideSomething)
        {
            hit.transform.GetComponent<MeshRenderer>().enabled = false;

            wallsReEnable = hit.transform;


            //Debug.Log($"Hit {hit.transform.name}");
        }

        if (!collideSomething)
        {
            wallsReEnable.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }






    private void Awake()
    {
        initialDifference = followTarget.position - transform.position;
    }

    private void Update()
    {
        RaycastDart();
        transform.position = followTarget.position - initialDifference;
    }
}
