public class RewardController
{
    private DailyRewardView _dailyRewardView;
    private DailyRewardController _dailyRewardController;

    private WeeklyRewardView _weeklyRewardView;
    private WeeklyRewardController _weeklyRewardController;

    public RewardController(DailyRewardView dailyRewardView, WeeklyRewardView weeklyRewardView)
    {
        _dailyRewardView = dailyRewardView;
        _weeklyRewardView = weeklyRewardView;
    }

    public void RefreshView()
    {
        _dailyRewardController = new DailyRewardController(_dailyRewardView);
        _dailyRewardController.RefreshView();

        _weeklyRewardController = new WeeklyRewardController(_weeklyRewardView);
        _weeklyRewardController.RefreshView();
    }
}
