using Profile;
using System.Collections.Generic;
using Ui;
using UnityEngine;

internal class MainController : BaseController
{
    private Transform _placeForUi;
    private ProfilePlayer _profilePlayer;
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private InventoryController _inventoryController;
    private readonly List<ItemConfig> _itemConfigs;
    private RewardController _rewardController;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemConfig)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _itemConfigs = itemConfig;
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                break;

            case GameState.Game:
                _inventoryController = new InventoryController(_itemConfigs, _profilePlayer, _placeForUi);
                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                _rewardController?.Dispose();
                break;

            case GameState.Reward:
                _rewardController = new RewardController(_placeForUi, _profilePlayer);
                break;

            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _inventoryController?.Dispose();
                break;
        }
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        _inventoryController?.Dispose();
        base.OnDispose();
    }
}
