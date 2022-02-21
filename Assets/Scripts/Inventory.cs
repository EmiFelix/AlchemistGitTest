using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private Dictionary<string, int> myInventory = new Dictionary<string, int>();

    public Text inventoryDisplay;

    // Start is called before the first frame update
    void Start()
    {
        myInventory.Add("Flask", 1);

        inventoryDisplay.text = "";
        foreach(var item in myInventory)
        {
            
            inventoryDisplay.text += "Item: " + item.Key + " Quantity: " + item.Value;
            
        }



    }

    



    // Update is called once per frame
    void Update()
    {
        
    }
}
