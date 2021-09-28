using System.Collections.Generic;

public interface IInventoryModel
{
    List<IItem> GetEquippedItems();
    void EquipItem(IItem item);
    void UnequipItem(IItem item);
}