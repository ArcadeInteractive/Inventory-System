using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container
{
    private List<Slot> slots = new List<Slot>();
    private GameObject spawnedContainerPrefab;
    private Inventory containerInventory;
    private Inventory playerInventory;

    public Container(Inventory containerInventory, Inventory playerInventory)
    {
        this.containerInventory = containerInventory;
        this.playerInventory = playerInventory;
        openContainer();
    }

    public void addSlotToContainer(Inventory inventory, int slotID, float x, float y, int slotSize)
    {
        GameObject spawnedSlot = Object.Instantiate(InventoryManager.INSTANCE.slotPrefab);
        Slot slot = spawnedSlot.GetComponent<Slot>();
        RectTransform slotRT = slot.GetComponent<RectTransform>();
        slot.setSlot(inventory, slotID, this);
        spawnedSlot.transform.SetParent(spawnedContainerPrefab.transform);
        spawnedSlot.transform.SetAsFirstSibling();
        slotRT.anchoredPosition = new Vector2(x,y);
        slotRT.sizeDelta = Vector2.one * slotSize;
        slotRT.localScale = Vector3.one;
        slots.Add(slot);
    }

    public void updateSlots()
    {
        foreach(Slot slot in slots)
        {
            slot.updateSlot();
        }
    }

    public void openContainer()
    {
        spawnedContainerPrefab = Object.Instantiate(getContainerPrefab(), InventoryManager.INSTANCE.transform);
        spawnedContainerPrefab.transform.SetAsFirstSibling();
    }

    public void closeContainer()
    {
        Object.Destroy(spawnedContainerPrefab);
    }

    //Needs to be overriden can not be left blank or null
    public virtual GameObject getContainerPrefab()
    {
        return null;
    }

    public GameObject getSpawnedContainer()
    {
        return spawnedContainerPrefab;
    }

    public Inventory getContainerInventory()
    {
        return containerInventory;
    }

    public Inventory getPlayerInventory()
    {
        return playerInventory;
    }
}