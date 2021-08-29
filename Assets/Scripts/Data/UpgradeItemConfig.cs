using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade item", menuName = "Upgrade item", order = 0)]
public class UpgradeItemConfig : ScriptableObject
{
    [SerializeField] private ItemConfig itemConfig;
    [SerializeField] private UpgradeType type;
    [SerializeField] private float value;

    public int Id => itemConfig.Id;

    public UpgradeType Type => type;
    public float Value => value;
}

public enum UpgradeType
{
    None,
    Speed,
    Control
}