using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Player player;
    private InventoryManager inventoryManager;
    private Inventory inventory = new Inventory(24);

	void Start ()
    {
        player = FindObjectOfType<Player>();
        inventoryManager = InventoryManager.INSTANCE;
    }

    private void OnMouseOver()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= 2 && !inventoryManager.hasInventoryCurrentlyOpen())
        {
            if(Input.GetMouseButtonDown(1))//Right Click
            {
                inventoryManager.openContainer(new ContainerChest(inventory, player.getInventory()));
            }
        }
    }
}