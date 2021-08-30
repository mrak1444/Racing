using Profile;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Inventory" };
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryView;
    private ProfilePlayer _profilePlayer;

    public InventoryController(List<ItemConfig> itemConfigs, ProfilePlayer profilePlayer)
    {
        _inventoryModel = new InventoryModel();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _inventoryView = new InventoryView(profilePlayer);
        _profilePlayer = profilePlayer;
        _inventoryView = LoadView();
        _inventoryView.Init();
    }

    private IInventoryView LoadView()
    {
        GameObject objectView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objectView);
        return objectView.GetComponent<IInventoryView>();
    }

    public void ShowInventory()
    {
        foreach(var item in _itemsRepository.Items.Values)
        {
            _inventoryModel.EquipItem(item);

            var equippedItems = _inventoryModel.GetEquippedItems();

            _inventoryView.Display(equippedItems);
        }
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
}
