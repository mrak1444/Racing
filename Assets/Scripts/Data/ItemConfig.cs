using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class ItemConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _title;
    [SerializeField] private Sprite _view;
    [SerializeField] private string _obj;
    [SerializeField] private UpgradeType _type;
    [SerializeField] private float _value;

    public int Id => _id;
    public string Title => _title;
    public Sprite View => _view;
    public string Obj => _obj;
    public UpgradeType Type => _type;
    public float Value => _value;
}

public enum UpgradeType
{
    None,
    Speed,
    Gun
}