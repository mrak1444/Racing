using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class WeeklyRewardController
{
    private WeeklyRewardView _weeklyRewardView;

    private List<ContainerRewardSlotView> _slotsWeekly = new List<ContainerRewardSlotView>();

    private bool _isGetReward;

    public WeeklyRewardController(WeeklyRewardView weeklyRewardView)
    {
        _weeklyRewardView = weeklyRewardView;
    }

    public void RefreshView()
    {
        InitSlots();
        _weeklyRewardView.StartCoroutine(RewardsStateUpdater());
        RefreshUi();
        SubscribeButtons();
    }

    private void InitSlots()
    {
        _slotsWeekly = new List<ContainerRewardSlotView>();
        
        for (var i = 0; i < _weeklyRewardView.RewardsWeekly.Count; i++)
        {
            var instantSlot = Object.Instantiate(_weeklyRewardView.ContainerRewardSlotView, _weeklyRewardView.RootSlotsRewardWeekly, false);
            _slotsWeekly.Add(instantSlot);
        }
    }

    private IEnumerator RewardsStateUpdater()
    {
        while (true)
        {
            RefreshRewardsState();
            yield return new WaitForSeconds(1);
        }
    }

    private void RefreshRewardsState()
    {
        _isGetReward = true;

        if (_weeklyRewardView.TimeGetReward.HasValue)
        {
            var timeSpan = DateTime.UtcNow - _weeklyRewardView.TimeGetReward.Value;

            if (timeSpan.Seconds > _weeklyRewardView.TimeDeadline)
            {
                _weeklyRewardView.TimeGetReward = null;
                _weeklyRewardView.CurrentSLotInActive = 0;
            }
            else if (timeSpan.Seconds < _weeklyRewardView.TimeCooldown)
            {
                _isGetReward = false;
            }
        }

        RefreshUi();
    }

    private void RefreshUi()
    {
        _weeklyRewardView.GetRewardButton.interactable = _isGetReward;

        if (_isGetReward)
        {
            _weeklyRewardView.TimerNewReward.text = "The reward is received today";
        }
        else
        {
            if (_weeklyRewardView.TimeGetReward != null)
            {
                var nextClaimTime = _weeklyRewardView.TimeGetReward.Value.AddSeconds(_weeklyRewardView.TimeCooldown);
                var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

                var timeGetReward = $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                _weeklyRewardView.TimerNewReward.text = $"Time to get the next reward: {timeGetReward}";

                _weeklyRewardView.SliderRewardWeekly.fillAmount = (float)(1 - (currentClaimCooldown.TotalSeconds / _weeklyRewardView.TimeCooldown));
            }
        }

        for (var i = 0; i < _slotsWeekly.Count; i++)
            _slotsWeekly[i].SetData(_weeklyRewardView.RewardsWeekly[i], i + 1, i == _weeklyRewardView.CurrentSLotInActive);
    }

    private void SubscribeButtons()
    {
        _weeklyRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
        _weeklyRewardView.ResetButton.onClick.AddListener(ResetTimer);
    }

    private void ClaimReward()
    {
        if (!_isGetReward)
            return;

        var reward = _weeklyRewardView.RewardsWeekly[_weeklyRewardView.CurrentSLotInActive];

        switch (reward.RewardType)
        {
            case RewardType.Wood:
                CurrencyView.Instance.AddWood(reward.CountCurrency);
                break;
            case RewardType.Diamond:
                CurrencyView.Instance.AddDiamond(reward.CountCurrency);
                break;
        }

        _weeklyRewardView.TimeGetReward = DateTime.UtcNow;
        _weeklyRewardView.CurrentSLotInActive = (_weeklyRewardView.CurrentSLotInActive + 1) % _weeklyRewardView.RewardsWeekly.Count;

        RefreshRewardsState();
    }

    private void ResetTimer()
    {
        PlayerPrefs.DeleteAll();
    }
}