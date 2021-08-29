using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryView;

    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _inventoryView = new InventoryView();
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
}
