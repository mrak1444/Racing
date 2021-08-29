using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource", order = 0)]
public class UpgradeItemConfigDataSource : ScriptableObject
{
    [SerializeField] private UpgradeItemConfig[] itemConfigs;

    public UpgradeItemConfig[] ItemConfigs => itemConfigs;
}
