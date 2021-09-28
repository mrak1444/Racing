using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    private const string WoodKey = nameof(WoodKey);
    private const string DiamondKey = nameof(DiamondKey);

    [SerializeField] private TMP_Text _currenCountWood;
    [SerializeField] private TMP_Text _currenCountDiamond;

    public static CurrencyView Instance { get; private set; }

    private int Wood
    {
        get => PlayerPrefs.GetInt(WoodKey, 0);
        set => PlayerPrefs.SetInt(WoodKey, value);
    }

    private int Diamond
    {
        get => PlayerPrefs.GetInt(DiamondKey, 0);
        set => PlayerPrefs.SetInt(DiamondKey, value);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        RefreshText();
    }

    public void AddWood(int value)
    {
        Wood += value;
        RefreshText();
    }

    public void AddDiamond(int value)
    {
        Diamond += value;
        RefreshText();
    }

    private void RefreshText()
    {
        _currenCountWood.text = Wood.ToString();
        _currenCountDiamond.text = Diamond.ToString();
    }
}
