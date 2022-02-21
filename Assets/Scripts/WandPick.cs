using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandPick : MonoBehaviour
{
    [SerializeField] private GameObject ice;

    [SerializeField] private Transform iceSpawn;

    [SerializeField] private int iceCooldown;
    [SerializeField] private int nextIce;


    private void Start()
    {
        
    }

    public void PickedAbility2()
    {
        if (Time.time > nextIce)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Instantiate(ice, iceSpawn.position, transform.rotation);
                nextIce = (int)(Time.time + iceCooldown);

            }
        }

            

    }

    

    private void Update()
    {
        PickedAbility2();
    }
}
