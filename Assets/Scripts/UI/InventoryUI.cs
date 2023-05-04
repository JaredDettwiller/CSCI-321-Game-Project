using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Inventory inventory;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        if (inventoryPanel.activeSelf)
        {
            updateItemCounter();
        }

        if(Input.GetKeyDown(KeyCode.I) && !inventoryPanel.activeSelf)
        {
            // Open the inventory
            inventoryPanel.SetActive(true);
            
        } 
        else if(Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeSelf)
        {
            // Close the inventory
            inventoryPanel.SetActive(false);
        }
    }
    public void buttonOnClick(string itemUsed)
    {
        switch (itemUsed)
        {
            case "Potion":
                if (!inventory.usePotion())
                {
                    // You can't use this right now!
                    print("You can't use this right now");
                    Transform potionButton = inventoryPanel.transform.GetChild(1).GetChild(0);
                    potionButton.gameObject.GetComponent<ErrorPanel>().openErrorPanel();
                }
                break;
            case "Fairy":
                // Player can't use fairy in the inventory panel
                Transform fairyButton = inventoryPanel.transform.GetChild(1).GetChild(1);
                fairyButton.gameObject.GetComponent<ErrorPanel>().openErrorPanel();
                break;
            case "Key":
                // Player can't use key in the inventory panel
                Transform keyButton = inventoryPanel.transform.GetChild(1).GetChild(2);
                keyButton.gameObject.GetComponent<ErrorPanel>().openErrorPanel();
                break;
                   
        }
    }

    private void updateItemCounter()
    {
        Transform inventoryButtonPanel = inventoryPanel.transform.GetChild(1);
        Transform potionButton = inventoryButtonPanel.GetChild(0);
        Transform fairyButton = inventoryButtonPanel.GetChild(1);
        Transform keyButton = inventoryButtonPanel.GetChild(2);

        // Update Potion
        Text potionText = potionButton.GetChild(0).gameObject.GetComponent<Text>();

        potionText.text = "Potion (x" + inventory.numberOfPotions + ")";

        // Update Fairy
        Text fairyText = fairyButton.GetChild(0).gameObject.GetComponent<Text>();
        fairyText.text = "Fairy in a bottle (x" + inventory.numberOfFairies + ")";

        // Update Key
        Text keyText = keyButton.GetChild(0).gameObject.GetComponent<Text>();
        keyText.text = "Castle Keys (x"+ inventory.goldKeys + ")";
    }
}
