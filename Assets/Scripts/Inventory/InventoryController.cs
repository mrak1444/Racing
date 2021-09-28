using Profile;
using System.Collections.Generic;
using Tools;
using UnityEngine;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Inventory" };  //mainMenu  Inventory
    private readonly ResourcePath _currencyPath = new ResourcePath { PathResource = "Prefabs/CurrencyWindow" };
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly InventoryView _inventoryView;
    private ProfilePlayer _profilePlayer;                  //дописать применение инвенторя на машинку

    public InventoryController(List<ItemConfig> itemConfigs, ProfilePlayer profilePlayer, Transform placeForUi)
    {
        _inventoryModel = new InventoryModel();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _profilePlayer = profilePlayer;
        _inventoryView = LoadView(placeForUi);
        _inventoryView.Init(_itemsRepository.Items, _inventoryModel, profilePlayer);
    }

    private InventoryView LoadView(Transform placeForUi)
    {
        Object.Instantiate(ResourceLoader.LoadPrefab(_currencyPath), placeForUi, false);
        GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<InventoryView>();
    }

    public void ShowInventory()
    {
        //дописать применение инвенторя на машинку
    }
}
