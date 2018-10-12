using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<ItemStack> inventoryContents = new List<ItemStack>();

    public Inventory(int size)
    {
        for(int i = 0; i < size; i++)
        {
            inventoryContents.Add(new ItemStack(i));
        }
    }

    public bool addItem(ItemStack input)
    {
        foreach(ItemStack stack in inventoryContents)
        {
            if(stack.isEmpty())//Itemstack Has no item
            {
                stack.setStack(input);
                return true;
            }
            else//Itemstack has an item
            {
                if(ItemStack.areItemsEqual(input, stack))
                {
                    if (stack.canAddToo(input.getCount()))
                    {
                        stack.increaseAmount(input.getCount());
                        return true;
                    }
                    else
                    {
                        int difference = (stack.getCount() + input.getCount()) - stack.getItem().maxStackSize;
                        stack.setCount(stack.getItem().maxStackSize);
                        input.setCount(difference);
                    }
                }
            }
        }

        return false;
    }

    public ItemStack getStackInSlot(int index)
    {
        return inventoryContents[index];
    }

    public List<ItemStack> getInventoryStacks()
    {
        return inventoryContents;
    }
}