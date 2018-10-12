using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStack
{
    public static ItemStack Empty = new ItemStack();
    public Item item;
    public int count;
    public int slotID;

    public ItemStack()
    {
        this.item = null;
        this.count = 0;
        this.slotID = -1;
    }

    public ItemStack(int slotID)
    {
        this.item = null;
        this.count = 0;
        this.slotID = slotID;
    }

    public ItemStack(Item item, int count)
    {
        this.item = item;
        this.count = count;
        this.slotID = -1;
    }

    public ItemStack(Item item, int count, int slotID)
    {
        this.item = item;
        this.count = count;
        this.slotID = slotID;
    }

    public Item getItem()
    {
        return this.item;
    }

    public int getCount()
    {
        return this.count;
    }

    public void setStack(ItemStack stackIn)
    {
        this.item = stackIn.getItem();
        this.count = stackIn.getCount();
    }

    public bool isEmpty()
    {
        return this.count < 1;
    }

    public void increaseAmount(int amount)
    {
        this.count += amount;
    }

    public void decreaseAmount(int amount)
    {
        this.count -= amount;
    }

    public void setCount(int amount)
    {
        this.count = amount;
    }

    public bool canAddToo(int amount)
    {
        return (this.count + amount) <= this.item.maxStackSize;
    }

    public ItemStack splitStack(int amount)
    {
        int i = Mathf.Min(amount, count);
        ItemStack copiedStack = this.copy();
        copiedStack.setCount(i);
        this.decreaseAmount(i);
        return copiedStack;
    }

    public ItemStack copy()
    {
        return new ItemStack(this.item, this.count, this.slotID);
    }

    public bool isItemEqual(ItemStack stackIn)
    {
        return !stackIn.isEmpty() && this.item == stackIn.getItem();
    }

    public static bool areItemsEqual(ItemStack stackA, ItemStack stackB)
    {
        return stackA == stackB ? true : (!stackA.isEmpty() && !stackB.isEmpty() ? stackA.isItemEqual(stackB) : false);
    }
}