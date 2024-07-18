using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;

    private void Start()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this._itemImage.gameObject.SetActive(false);
        this._title.text = "";
        this._description.text = "";
    }

    public void SetDescription(Sprite sprite, string itemTitle, string itemDescription)
    {
        this._itemImage.gameObject.SetActive(true);
        this._itemImage.sprite = sprite;
        this._title.text = itemTitle;
        this._description.text = itemDescription;
    }
}
