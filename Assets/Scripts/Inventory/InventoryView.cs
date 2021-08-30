using Profile;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

internal class InventoryView : MonoBehaviour , IInventoryView
{
    [SerializeField] private Image _img1;
    [SerializeField] private Image _img2;
    [SerializeField] private Button _but1;
    [SerializeField] private Button _but2;
    private Car _car;
    private float _speed1;
    private float _speed2;
    private string _resourcePath1;
    private string _resourcePath2;
    private ProfilePlayer _profilePlayer;

    public InventoryView(ProfilePlayer profilePlayer)
    {
        _car = profilePlayer.CurrentCar;
        _profilePlayer = profilePlayer;
    }

    public void Init() //UnityAction startGame)
    {
        _but1.onClick.AddListener(startGame1);
        _but2.onClick.AddListener(startGame2);
    }

    private void startGame2()
    {
        _car.Speed = _speed1;
        _car.ResourcePath = _resourcePath1;
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    private void startGame1()
    {
        Debug.Log(_speed2);
        _car.Speed = _speed2;
        _car.ResourcePath = _resourcePath2;
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    public void Display(List<IItem> items)
    {
        _img1.sprite = items[0].View;
        _speed1 = items[0].Value;
        _resourcePath1 = items[0].Obj;

        _img2.sprite = items[1].View;
        _speed2 = items[1].Value;
        _resourcePath2 = items[1].Obj;

    }

    protected void OnDestroy()
    {
        _but1.onClick.RemoveAllListeners();
        _but2.onClick.RemoveAllListeners();
    }
}
