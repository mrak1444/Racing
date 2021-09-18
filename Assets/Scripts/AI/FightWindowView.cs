using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightWindowView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countMoneyText;
    [SerializeField] private TMP_Text _countHealthText;
    [SerializeField] private TMP_Text _countPowerText;
    [SerializeField] private TMP_Text _countPowerEnemy;

    [SerializeField] private Button _addMoneyButton;
    [SerializeField] private Button _minusMoneyButton;

    [SerializeField] private Button _addHealtButton;
    [SerializeField] private Button _minusHealtButton;

    [SerializeField] private Button _addPowerButton;
    [SerializeField] private Button _minusPowerButton;

    [SerializeField] private Button _fightButton;
    [SerializeField] private Button _passByButton;

    private Enemy _enemy;
    private Money _money;
    private Health _health;
    private Power _power;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;

    private void Start()
    {
        _enemy = new Enemy("Flappy");

        _money = new Money("Money");
        _money.Attach(_enemy);
        _health = new Health("Health");
        _health.Attach(_enemy);
        _power = new Power("Power");
        _power.Attach(_enemy);

        _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _addHealtButton.onClick.AddListener(() => ChangeHelath(true));
        _minusHealtButton.onClick.AddListener(() => ChangeHelath(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _fightButton.onClick.AddListener(Fight);
        _passByButton.onClick.AddListener(PassBy);
    }

    private void OnDestroy()
    {
        _addMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _addHealtButton.onClick.RemoveAllListeners();
        _minusHealtButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _health.Detach(_enemy);
        _power.Detach(_enemy);
    }

    private void PassBy()
    {
        Debug.Log("You walked by");
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power ? "Win" : "Lose");
    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void ChangeHelath(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player money: {countChangeData}";
                _money.CountMoney = countChangeData;
                break;

            case DataType.Health:
                _countHealthText.text = $"Player health: {countChangeData}";
                _health.CountHealth = countChangeData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player power: {countChangeData}";
                _power.CountPower = countChangeData;
                break;
        }

        _countPowerEnemy.text = $"Enemy power: {_enemy.Power}";

        _passByButton.gameObject.SetActive(_allCountPowerPlayer <= 2);
    }
}
