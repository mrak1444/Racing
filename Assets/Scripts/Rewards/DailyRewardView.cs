using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardView : MonoBehaviour
{
    private const string CurrentSLotInActiveKey = nameof(CurrentSLotInActiveKey);
    private const string TimeGetRewardKey = nameof(TimeGetRewardKey);

    [SerializeField] private float _timeCooldown = 86400;
    [SerializeField] private float _timeDeadline = 172800;
    [SerializeField] private List<Reward> _rewardsDaily;
    [SerializeField] private TMP_Text _timerNewReward;
    [SerializeField] private Transform _rootSlotsRewardDaily;
    [SerializeField] private ContainerRewardSlotView _containerRewardSlotView;
    [SerializeField] private Button _getRewardButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Image _sliderRewardDaily;

    public Button ResetButton => _resetButton;

    public Button GetRewardButton => _getRewardButton;

    public ContainerRewardSlotView ContainerRewardSlotView => _containerRewardSlotView;

    public Transform RootSlotsRewardDaily => _rootSlotsRewardDaily;

    public TMP_Text TimerNewReward => _timerNewReward;

    public List<Reward> RewardsDaily => _rewardsDaily;

    public float TimeDeadline => _timeDeadline;

    public float TimeCooldown => _timeCooldown;

    public Image SliderRewardDaily => _sliderRewardDaily;

    public int CurrentSLotInActive
    {
        get => PlayerPrefs.GetInt(CurrentSLotInActiveKey, 0);
        set => PlayerPrefs.SetInt(CurrentSLotInActiveKey, value);
    }

    public DateTime? TimeGetReward
    {
        get
        {
            var data = PlayerPrefs.GetString(TimeGetRewardKey, null);
            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
            else
                PlayerPrefs.DeleteKey(TimeGetRewardKey);
        }
    }

    private void OnDestroy()
    {
        _getRewardButton.onClick.RemoveAllListeners();
        _resetButton.onClick.RemoveAllListeners();
    }
}
