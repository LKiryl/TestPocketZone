using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryMenu _inventoryMenu;
    [SerializeField] private int _inventorySize = 10;

    private void Start()
    {
        _inventoryMenu.InitializeInventory(_inventorySize);
    }
}
