using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public GameObject thisLoot;
    public int LootChance;
}

[CreateAssetMenu]
public class ItemDrop : ScriptableObject
{

    public Loot[] loots;   
    
    public GameObject LootHP()
    {
        int itemProb = 0;
        int currentProb = Random.Range(0, 100);
        for(int i = 0; i < loots.Length; i++)
        {
            itemProb += loots[i].LootChance;

            if(currentProb <= itemProb)
            {
                return loots[i].thisLoot;
            }

        }
          
        return null;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*
    [SerializeField] private GameObject[] itemList;
    
    private int itemNum;

    private int randNum;

    [SerializeField] private Transform enemyPlaceToDrop;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void DropOnDeath()
    {
        if (GameObject.FindGameObjectsWithTag("SkullyEnemy").Length == 0)
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        
            randNum = Random.Range(0, 101);
            Debug.Log("Random num is " + randNum);

            if (randNum >= 95)
            {
                itemNum = 0;
                Instantiate(itemList[itemNum], enemyPlaceToDrop.position, Quaternion.identity);
            }
            else if (randNum > 75 && randNum < 95)
            {
                itemNum = 1;
                Instantiate(itemList[itemNum], enemyPlaceToDrop.position, Quaternion.identity);
            }
            else if (randNum > 40 && randNum < 75)
            {
                itemNum = 2;
                Instantiate(itemList[itemNum], enemyPlaceToDrop.position, Quaternion.identity);
            }
        
    }


    // Update is called once per frame
    void Update()
    {
        DropOnDeath();
    }*/
}
