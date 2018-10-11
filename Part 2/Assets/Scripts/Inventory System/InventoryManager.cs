using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }
    #endregion

    public GameObject slotPrefab;
    public List<ContainerGetter> containers = new List<ContainerGetter>();
    private Container currentOpenContainer;
    private ItemStack curDraggedStack = ItemStack.Empty;
    private GameObject spawnedDragStack;
    private DraggedItemStack dragStack;

    private void Start()
    {
        dragStack = GetComponentInChildren<DraggedItemStack>();
    }

    public GameObject getContainerPrefab(string name)
    {
        foreach(ContainerGetter container in containers)
        {
            if(container.containerName == name)
            {
                return container.containerPrefab;
            }
        }

        return null;
    }

    public void openContainer(Container container)
    {
        if(currentOpenContainer != null)
        {
            currentOpenContainer.closeContainer();
        }

        currentOpenContainer = container;
    }

    public void closeContainer()
    {
        if (currentOpenContainer != null)
        {
            currentOpenContainer.closeContainer();
        }
    }

    public ItemStack getDraggedItemStack()
    {
        return curDraggedStack;
    }

    public void setDragedItemStack(ItemStack stackIn)
    {
        dragStack.setDraggedStack(curDraggedStack = stackIn);
    }
}

[System.Serializable]
public class ContainerGetter
{
    public string containerName;
    public GameObject containerPrefab;
}