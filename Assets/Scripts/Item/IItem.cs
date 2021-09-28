using UnityEngine;

public interface IItem
{
    int Id { get; set; }
    ItemInfo Info { get; set; }
    Sprite View { get; set; }
    string Obj { get; set; }
    UpgradeType Type { get; set; }
    float Value { get; set; }
}