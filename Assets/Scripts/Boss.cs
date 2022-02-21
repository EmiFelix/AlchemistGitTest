using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] private Transform eyesTransform;

    [SerializeField] private float maxDistance;

    [SerializeField] private LayerMask wallLayerMask;






    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void RaycastDart()
    {
        RaycastHit hit;

        var collideSomething = Physics.Raycast(eyesTransform.position, transform.forward, out hit, maxDistance, wallLayerMask);

        if (collideSomething)
        {
            Debug.Log($"Hit {hit.transform.name}");
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            RaycastDart();
        }
    }
}
