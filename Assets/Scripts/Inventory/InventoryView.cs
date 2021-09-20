using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Profile;

internal class InventoryView : MonoBehaviour
{
    [SerializeField] private float _duration = 0.3f;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _startMenuInventory;
    [SerializeField] private Button _startMenuReward;
    [SerializeField] private Button _startMenuFight;
    [SerializeField] private Button _backMenu;
    [SerializeField] private Image _background;
    [SerializeField] private Image[] _inventoryButtonImg = new Image[4];
    [SerializeField] private Button[] _inventoryButton = new Button[4];
    [SerializeField] private Color _colorOpenPopUp;
    [SerializeField] private Color _colorClosePopUp;

    private IInventoryModel _inventoryModel;
    private ProfilePlayer _profilePlayer;

    public void Init(IReadOnlyDictionary<int, IItem> Items, IInventoryModel inventoryModel, ProfilePlayer profilePlayer)
    {
        Display(Items);
        _inventoryModel = inventoryModel;
        _startMenuInventory.onClick.AddListener(StartMenuInventory);
        _startMenuReward.onClick.AddListener(StartMenuReward);
        _startMenuFight.onClick.AddListener(StartMenuFight);
        _backMenu.onClick.AddListener(BackMenu);
        _profilePlayer = profilePlayer;
    }

    private void StartMenuFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
    }

    private void StartMenuReward()
    {
        _profilePlayer.CurrentState.Value = GameState.Reward;
    }

    private void StartMenuInventory()
    {
        _menu.SetActive(true);

        _startMenuInventory.gameObject.SetActive(false);

        var sequence = DOTween.Sequence();
        sequence.Insert(0.0f, _menu.transform.DOScale(Vector3.one, _duration));
        sequence.Insert(0.2f, _background.DOColor(_colorOpenPopUp, _duration));
        sequence.OnComplete(() =>
        {
            sequence = null;
        });
    }

    private void BackMenu()
    {
        _startMenuInventory.gameObject.SetActive(true);

        var sequence = DOTween.Sequence();

        sequence.Insert(0.0f, _background.DOColor(_colorClosePopUp, _duration));
        sequence.Insert(0.2f, _menu.transform.DOScale(Vector3.zero, _duration));

        sequence.OnComplete(() =>
        {
            sequence = null;
            _menu.SetActive(false);
        });

        foreach (var n in _inventoryModel.GetEquippedItems())
        {
            Debug.Log(n.Info.Title);
        }
    }

    public void EquipItem(IItem Item)
    {
        if (!_inventoryModel.GetEquippedItems().Contains(Item))
            _inventoryModel.EquipItem(Item);
        else
            _inventoryModel.UnequipItem(Item);
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
        _startMenuInventory.onClick.RemoveAllListeners();
        _backMenu.onClick.RemoveAllListeners();
    }
}
