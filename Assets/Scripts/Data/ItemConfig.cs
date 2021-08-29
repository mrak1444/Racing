using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class ItemConfig : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string title;

    public int Id => id;
    public string Title => title;
}