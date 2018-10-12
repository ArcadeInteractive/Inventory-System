using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemIcon;
    public Text itemAmount;
    private int slotID;
    private ItemStack myStack;
    private Container attachedContainer;
    private InventoryManager inventoryManager;

    public void setSlot(Inventory attachedInventory, int slotID, Container attachedContainer)
    {
        this.slotID = slotID;
        this.attachedContainer = attachedContainer;
        myStack = attachedInventory.getStackInSlot(slotID);
        inventoryManager = InventoryManager.INSTANCE;
        updateSlot();
    }

    public void updateSlot()
    {
        if(!myStack.isEmpty())
        {
            itemIcon.enabled = true;
            itemIcon.sprite = myStack.getItem().ItemIcon;

            if(myStack.getCount() > 1)
            {
                itemAmount.text = myStack.getCount().ToString();
            }
            else
            {
                itemAmount.text = string.Empty;
            }
        }
        else
        {
            itemIcon.enabled = false;
            itemAmount.text = string.Empty;
        }
    }

    private void setSlotContents(ItemStack stackIn)
    {
        myStack.setStack(stackIn);
        updateSlot();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ItemStack curDraggedStack = inventoryManager.getDraggedItemStack();
        ItemStack stackCopy = myStack.copy();

        if (eventData.pointerId == -1)
        {
            onLeftClick(curDraggedStack, stackCopy);
        }

        if (eventData.pointerId == -2)
        {
            onRightClick(curDraggedStack, stackCopy);
        }
    }

    private void setTooltip(string nameIn)
    {
        inventoryManager.drawToolTip(nameIn);
    }

    private void onLeftClick(ItemStack curDraggedStack, ItemStack stackCopy)
    {
        if(!myStack.isEmpty() && curDraggedStack.isEmpty())
        {
            inventoryManager.setDragedItemStack(stackCopy);
            this.setSlotContents(ItemStack.Empty);
            setTooltip(string.Empty);
        }

        if(myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            this.setSlotContents(curDraggedStack);
            inventoryManager.setDragedItemStack(ItemStack.Empty);
            setTooltip(myStack.getItem().ItemName);
        }

        if(!myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            if(ItemStack.areItemsEqual(stackCopy, curDraggedStack))
            {
                if(stackCopy.canAddToo(curDraggedStack.getCount()))
                {
                    stackCopy.increaseAmount(curDraggedStack.getCount());
                    this.setSlotContents(stackCopy);
                    inventoryManager.setDragedItemStack(ItemStack.Empty);
                    setTooltip(myStack.getItem().ItemName);
                }
                else
                {
                    int difference = (stackCopy.getCount() + curDraggedStack.getCount()) - stackCopy.getItem().maxStackSize;
                    stackCopy.setCount(myStack.getItem().maxStackSize);
                    ItemStack dragCopy = curDraggedStack.copy();
                    dragCopy.setCount(difference);
                    this.setSlotContents(stackCopy);
                    inventoryManager.setDragedItemStack(dragCopy);
                    setTooltip(string.Empty);
                }
            }
            else
            {
                ItemStack curDragCopy = curDraggedStack.copy();
                this.setSlotContents(curDraggedStack);
                inventoryManager.setDragedItemStack(stackCopy);
                setTooltip(string.Empty);

            }
        }
    }

    private void onRightClick(ItemStack curDraggedStack, ItemStack stackCopy)
    {
        if(!myStack.isEmpty() && curDraggedStack.isEmpty())
        {
            ItemStack stack = stackCopy.splitStack((stackCopy.getCount() / 2));
            inventoryManager.setDragedItemStack(stack);
            this.setSlotContents(stackCopy);
            setTooltip(string.Empty);
        }

        if(myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            this.setSlotContents(new ItemStack(curDraggedStack.getItem(), 1));
            ItemStack curDragCopy = curDraggedStack.copy();
            curDragCopy.decreaseAmount(1);
            inventoryManager.setDragedItemStack(curDragCopy);
            setTooltip(string.Empty);
        }

        if(!myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            if(ItemStack.areItemsEqual(stackCopy, curDraggedStack))
            {
                if(myStack.canAddToo(1))
                {
                    stackCopy.increaseAmount(1);
                    this.setSlotContents(stackCopy);
                    ItemStack dragCopy = curDraggedStack.copy();
                    dragCopy.decreaseAmount(1);
                    inventoryManager.setDragedItemStack(dragCopy);
                    setTooltip(string.Empty);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemStack curDraggedStack = inventoryManager.getDraggedItemStack();

        if(!myStack.isEmpty() && curDraggedStack.isEmpty())
        {
            setTooltip(myStack.getItem().ItemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        setTooltip(string.Empty);
    }
}