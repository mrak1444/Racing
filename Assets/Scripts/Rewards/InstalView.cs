using UnityEngine;

public class InstalView : MonoBehaviour
{
    [SerializeField] private DailyRewardView _dailyRewardView;
    [SerializeField] private WeeklyRewardView _weeklyRewardView;

    private RewardController _rewardController;

    private void Awake()
    {
        _rewardController = new RewardController(_dailyRewardView, _weeklyRewardView);
    }

    private void Start()
    {
        _rewardController.RefreshView();
    }
}
