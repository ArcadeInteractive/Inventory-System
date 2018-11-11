using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item[] itemsToAdd;
    
    private Inventory myInventory = new Inventory(24);
    private int selectedHotbarIndex = 0;
    private KeyCode[] hotbarControls = new KeyCode[]
    {
        KeyCode.Alpha1, //Key 1
        KeyCode.Alpha2, //Key 2
        KeyCode.Alpha3, //Key 3
        KeyCode.Alpha4, //Key 4
        KeyCode.Alpha5, //Key 5
        KeyCode.Alpha6 //Key 6
    };

    private void Start()
    {
        foreach(Item item in itemsToAdd)
        {
            myInventory.addItem(new ItemStack(item, 1));
        }

        InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
        InventoryManager.INSTANCE.resetInventoryStatus();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!InventoryManager.INSTANCE.hasInventoryCurrentlyOpen())
            {
                InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
            }
        }

        updateSelectedHotbarIndex(Input.GetAxis("Mouse ScrollWheel"));

        for(int i = 0; i < hotbarControls.Length; i++)
        {
            if(Input.GetKeyDown(hotbarControls[i]))
            {
                selectedHotbarIndex = i;
            }
        }
    }

    private void updateSelectedHotbarIndex(float direction)
    {
        if (direction > 0)
            direction = 1;

        if (direction < 0)
            direction = -1;

        for (selectedHotbarIndex -= (int)direction;
            selectedHotbarIndex < 0; selectedHotbarIndex += 6);

        while (selectedHotbarIndex >= 6)
            selectedHotbarIndex -= 6;
    }

    public int getSelectedHotbarIndex()
    {
        return selectedHotbarIndex;
    }

    public Inventory getInventory()
    {
        return myInventory;
    }
}