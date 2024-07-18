using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private InventoryItem _inventoryItem;

    private void Awake()
    {
        _canvas = transform.root.GetComponent<Canvas>();
        _inventoryItem = GetComponentInChildren<InventoryItem>();
    }

    private void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)_canvas.transform,
            Input.mousePosition,
            _canvas.worldCamera,
            out position);

        transform.position = _canvas.transform.TransformPoint(position);
    }

    public void SetData(Sprite sprite, int quantity)
    {
        _inventoryItem.SetData(sprite, quantity);
    }

    public void Toggle(bool value)
    {
        gameObject.SetActive(value);
    }
}
