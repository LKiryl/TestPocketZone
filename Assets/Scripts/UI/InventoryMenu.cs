using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public event Action<int> OnDescriptionRequested,
        OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    [SerializeField] private InventoryItem _itemPrefab;
    [SerializeField] private RectTransform _contentPanelTransform;
    [SerializeField] private ItemMenu _itemMenu;
    [SerializeField] private Follower _follower;

    private List<InventoryItem> _listInvetoryItems = new List<InventoryItem>();

    private int _currentDraggedItemIndex = -1;
    private void Start()
    {
        Hide();
        _follower.Toggle(false);
        _itemMenu.ResetDescription();
    }
    public void InitializeInventory(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryItem item = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(_contentPanelTransform);
            _listInvetoryItems.Add(item);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrag += HandleBeginDrag;
            item.OnItemDroppedOn += HandleSwap;
            item.OnItemEndDrag += HandleEndDrag;
            item.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    public void UpdateData(int itemIndex,
        Sprite itemImage, int itemQuality)
    {
        if(_listInvetoryItems.Count > itemIndex)
        {
            _listInvetoryItems[itemIndex].SetData(itemImage, itemQuality);
        }
    }

    public void CreateDraggedItem(Sprite sprite , int quantity) 
    {
        _follower.Toggle(true);
        _follower.SetData(sprite, quantity);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDraggtedItem();
    }

    private void ResetSelection()
    {
        _itemMenu.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach(InventoryItem item in _listInvetoryItems)
        {
            item.Deselect();
        }
    }

    private void HandleShowItemActions(InventoryItem item)
    {
        throw new NotImplementedException();
    }

    private void HandleEndDrag(InventoryItem item)
    {
        ResetDraggtedItem();
    }

    private void HandleSwap(InventoryItem item)
    {
        int index = _listInvetoryItems.IndexOf(item);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(_currentDraggedItemIndex, index);
    }

    private void ResetDraggtedItem()
    {
        _follower.Toggle(false);
        _currentDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(InventoryItem item)
    {
        int index = _listInvetoryItems.IndexOf(item);
        if(index == -1) { return; }
        _currentDraggedItemIndex = index;
        HandleItemSelection(item);
        OnStartDragging?.Invoke(index);
        
        
    }

    private void HandleItemSelection(InventoryItem item)
    {
        int index = _listInvetoryItems.IndexOf(item);
        if (index == -1) { return; }
        OnDescriptionRequested?.Invoke(index);
    }

    

   

    
}
