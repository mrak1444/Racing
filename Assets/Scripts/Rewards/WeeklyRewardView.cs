using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyRewardView : MonoBehaviour
{
    private const string CurrentSLotInActiveKeyWeekly = nameof(CurrentSLotInActiveKeyWeekly);
    private const string TimeGetRewardKeyWeekly = nameof(TimeGetRewardKeyWeekly);

    [SerializeField] private float _timeCooldown = 604800;
    [SerializeField] private float _timeDeadline = 1209600;
    [SerializeField] private List<Reward> _rewardsWeekly;
    [SerializeField] private TMP_Text _timerNewReward;
    [SerializeField] private Transform _rootSlotsRewardWeekly;
    [SerializeField] private ContainerRewardSlotView _containerRewardSlotView;
    [SerializeField] private Button _getRewardButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Image _sliderRewardWeekly;

    public Button ResetButton => _resetButton;

    public Button GetRewardButton => _getRewardButton;

    public ContainerRewardSlotView ContainerRewardSlotView => _containerRewardSlotView;

    public Transform RootSlotsRewardWeekly => _rootSlotsRewardWeekly;

    public TMP_Text TimerNewReward => _timerNewReward;

    public List<Reward> RewardsWeekly => _rewardsWeekly;

    public float TimeDeadline => _timeDeadline;

    public float TimeCooldown => _timeCooldown;

    public Image SliderRewardWeekly => _sliderRewardWeekly;

    public int CurrentSLotInActive
    {
        get => PlayerPrefs.GetInt(CurrentSLotInActiveKeyWeekly, 0);
        set => PlayerPrefs.SetInt(CurrentSLotInActiveKeyWeekly, value);
    }

    public DateTime? TimeGetReward
    {
        get
        {
            var data = PlayerPrefs.GetString(TimeGetRewardKeyWeekly, null);
            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString(TimeGetRewardKeyWeekly, value.ToString());
            else
                PlayerPrefs.DeleteKey(TimeGetRewardKeyWeekly);
        }
    }

    private void OnDestroy()
    {
        _getRewardButton.onClick.RemoveAllListeners();
        _resetButton.onClick.RemoveAllListeners();
    }
}