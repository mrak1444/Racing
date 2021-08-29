using Profile;
using UnityEngine;
using Tools;
using System.Collections.Generic;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Transform _ui;
    private MainController _mainComtroller;

    [SerializeField] private UnityAdsTools _unityAdsTools;

    [SerializeField] private List<ItemConfig> _itemConfigs;

    private void Awake()
    {
        var _profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        _profilePlayer.CurrentState.Value = GameState.Start;
        _mainComtroller = new MainController(_ui, _profilePlayer, _itemConfigs);
    }

    protected void OnDestroy()
    {
        _mainComtroller?.Dispose();
    }
}
