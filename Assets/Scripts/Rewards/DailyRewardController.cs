using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class DailyRewardController
{
    private DailyRewardView _dailyRewardView;

    private List<ContainerRewardSlotView> _slotsDaily = new List<ContainerRewardSlotView>();

    private bool _isGetReward;

    public DailyRewardController(DailyRewardView dailyRewardView)
    {
        _dailyRewardView = dailyRewardView;
    }

    public void RefreshView()
    {
        InitSlots();
        _dailyRewardView.StartCoroutine(RewardsStateUpdater());
        RefreshUi();
        SubscribeButtons();
    }

    private void InitSlots()
    {
        _slotsDaily = new List<ContainerRewardSlotView>();

        for (var i = 0; i < _dailyRewardView.RewardsDaily.Count; i++)
        {
            var instantSlot = Object.Instantiate(_dailyRewardView.ContainerRewardSlotView, _dailyRewardView.RootSlotsRewardDaily, false);
            _slotsDaily.Add(instantSlot);
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

        if (_dailyRewardView.TimeGetReward.HasValue)
        {
            var timeSpan = DateTime.UtcNow - _dailyRewardView.TimeGetReward.Value;

            if (timeSpan.Seconds > _dailyRewardView.TimeDeadline)
            {
                _dailyRewardView.TimeGetReward = null;
                _dailyRewardView.CurrentSLotInActive = 0;
            }
            else if (timeSpan.Seconds < _dailyRewardView.TimeCooldown)
            {
                _isGetReward = false;
            }
        }

        RefreshUi();
    }

    private void RefreshUi()
    {
        _dailyRewardView.GetRewardButton.interactable = _isGetReward;

        if (_isGetReward)
        {
            _dailyRewardView.TimerNewReward.text = "The reward is received today";
        }
        else
        {
            if (_dailyRewardView.TimeGetReward != null)
            {
                var nextClaimTime = _dailyRewardView.TimeGetReward.Value.AddSeconds(_dailyRewardView.TimeCooldown);
                var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                
                var timeGetReward = $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                _dailyRewardView.TimerNewReward.text = $"Time to get the next reward: {timeGetReward}";

                _dailyRewardView.SliderRewardDaily.fillAmount = (float)(1-(currentClaimCooldown.TotalSeconds / _dailyRewardView.TimeCooldown));
            }
        }

        for (var i = 0; i < _slotsDaily.Count; i++)
            _slotsDaily[i].SetData(_dailyRewardView.RewardsDaily[i], i + 1, i == _dailyRewardView.CurrentSLotInActive);
    }

    private void SubscribeButtons()
    {
        _dailyRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
        _dailyRewardView.ResetButton.onClick.AddListener(ResetTimer);
    }

    private void ClaimReward()
    {
        if (!_isGetReward)
            return;

        var reward = _dailyRewardView.RewardsDaily[_dailyRewardView.CurrentSLotInActive];

        switch (reward.RewardType)
        {
            case RewardType.Wood:
                CurrencyView.Instance.AddWood(reward.CountCurrency);
                break;
            case RewardType.Diamond:
                CurrencyView.Instance.AddDiamond(reward.CountCurrency);
                break;
        }

        _dailyRewardView.TimeGetReward = DateTime.UtcNow;
        _dailyRewardView.CurrentSLotInActive = (_dailyRewardView.CurrentSLotInActive + 1) % _dailyRewardView.RewardsDaily.Count;

        RefreshRewardsState();
    }

    private void ResetTimer()
    {
        PlayerPrefs.DeleteAll();
    }
}
