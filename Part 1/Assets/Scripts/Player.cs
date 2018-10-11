using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isOpen;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!isOpen)
            {
                InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, null));
                isOpen = true;
            }
            else
            {
                InventoryManager.INSTANCE.closeContainer();
                isOpen = false;
            }
        }
    }
}