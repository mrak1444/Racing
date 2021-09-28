using UnityEngine;

public class Item : IItem
{
    public int Id { get; set; }
    public ItemInfo Info { get; set; }
    public Sprite View { get; set; }
    public string Obj { get; set; }
    public UpgradeType Type { get; set; }
    public float Value { get; set; }
}