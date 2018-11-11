using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerChest : Container
{
    public ContainerChest(Inventory containerInventory, Inventory playerInventory) : base(containerInventory, playerInventory)
    {
        //Player Hotbar Slots
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(playerInventory, i, 35 + (50 * i), -90, 50);
        }

        //Player Inventory Slots Row 1
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(playerInventory, 6 + i, 35 + (50 * i), 90, 50);
        }

        //Player Inventory Slots Row 2
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(playerInventory, 12 + i, 35 + (50 * i), 40, 50);
        }

        //Player Inventory Slots Row 3
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(playerInventory, 18 + i, 35 + (50 * i), -10, 50);
        }

        //Chest Inventory Slots Row 1
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(containerInventory, i, -285 + (50 * i), 90, 50);
        }

        //Chest Inventory Slots Row 2
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(containerInventory, 6 + i, -285 + (50 * i), 40, 50);
        }

        //Chest Inventory Slots Row 3
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(containerInventory, 12 + i, -285 + (50 * i), -10, 50);
        }

        //Chest Inventory Slots Row 4
        for (int i = 0; i < 6; i++)
        {
            addSlotToContainer(containerInventory, 18 + i, -285 + (50 * i), -60, 50);
        }
    }

    public override GameObject getContainerPrefab()
    {
        return InventoryManager.INSTANCE.getContainerPrefab("Chest Inventory");
    }
}