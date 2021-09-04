using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _startMenu;
    [SerializeField] private Button _backMenu;
    [SerializeField] private Image[] _inventoryButtonImg = new Image[4];
    [SerializeField] private Button[] _inventoryButton = new Button[4];

    public void Init(IReadOnlyDictionary<int, IItem> Items)
    {
        Display(Items);
        
        _startMenu.onClick.AddListener(StartMenu);
        _backMenu.onClick.AddListener(BackMenu);
    }

    private void StartMenu()
    {
        _menu.SetActive(true);
        _startMenu.gameObject.SetActive(false);
    }

    private void BackMenu()
    {
        _startMenu.gameObject.SetActive(true);
        _menu.SetActive(false);
    }

    private void Display(IReadOnlyDictionary<int, IItem> Items)
    {
        for(int i = 1; i <= Items.Count; i++)
        {
            _inventoryButtonImg[i-1].sprite = Items[i].View;
        }
    }

    protected void OnDestroy()
    {
        _startMenu.onClick.RemoveAllListeners();
        _backMenu.onClick.RemoveAllListeners();
    }
}
