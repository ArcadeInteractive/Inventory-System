using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item[] itemsToAdd;

    private Inventory myInventory = new Inventory(18);
    private bool isOpen;

    private void Start()
    {
        foreach(Item item in itemsToAdd)
        {
            myInventory.addItem(new ItemStack(item, 1));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
                isOpen = true;
            }
            else
            {
                InventoryManager.INSTANCE.closeContainer();
                isOpen = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
            {
                InventoryManager.INSTANCE.closeContainer();
                isOpen = false;
            }
        }
    }
}