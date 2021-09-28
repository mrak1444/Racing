using System.Collections.Generic;

internal class ItemsRepository : BaseController, IItemsRepository
{
    public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
    {
        PopulateItems(upgradeItemConfigs);
    }

    protected override void OnDispose()
    {
        _itemsMapById.Clear();
    }

    private void PopulateItems(List<ItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_itemsMapById.ContainsKey(config.Id)) continue;
            _itemsMapById.Add(config.Id, CreateItem(config));
        }
    }

    private IItem CreateItem(ItemConfig config)
    {
        return new Item
        {
            Id = config.Id,
            Info = new ItemInfo { Title = config.Title },
            View = config.View,
            Obj = config.Obj,
            Type = config.Type,
            Value = config.Value
        };
    }
}