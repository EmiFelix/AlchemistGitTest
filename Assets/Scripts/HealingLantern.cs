using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLantern : MonoBehaviour
{
    [SerializeField] private int healCD;

    [SerializeField] private int nextHeal;

    // HealAura

    [SerializeField] private Transform healSpawn;
    [SerializeField] private KeyCode ability3;

    public GameObject healAura;

    // public healAura healDamage;




    private void Ability3()
    {
        if(Time.time > nextHeal)
        {
            if (Input.GetKeyDown(ability3))
            {
                Instantiate(healAura, healSpawn.position, healSpawn.rotation);
                nextHeal = (int)(Time.time + healCD);
            }
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ability3();
    }
}