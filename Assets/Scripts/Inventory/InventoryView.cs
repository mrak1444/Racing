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
    public event Action<IItem> eventItem;

    private IInventoryModel _inventoryModel;

    public void Init(IReadOnlyDictionary<int, IItem> Items, IInventoryModel inventoryModel)
    {
        Display(Items);
        _inventoryModel = inventoryModel;
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
        foreach(var n in _inventoryModel.GetEquippedItems())
        {
            Debug.Log(n.Info.Title);
        }
    }

    public void EquipItem(IItem Item)
    {
        eventItem.Invoke(Item);
    }

    private void Display(IReadOnlyDictionary<int, IItem> Items)
    {
        for(int i = 1; i <= Items.Count; i++)
        {
            _inventoryButtonImg[i-1].sprite = Items[i].View;
            //_inventoryButton[i-1].onClick.AddListener(delegate () { EquipItem(Items[i]); });  //почему то данная строка не работает
        }
        _inventoryButton[0].onClick.AddListener(delegate () { EquipItem(Items[1]); });
        _inventoryButton[1].onClick.AddListener(delegate () { EquipItem(Items[2]); });
    }

    protected void OnDestroy()
    {
        _startMenu.onClick.RemoveAllListeners();
        _backMenu.onClick.RemoveAllListeners();
    }
}
