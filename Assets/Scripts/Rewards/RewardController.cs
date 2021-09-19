using System;
using Tools;
using UnityEngine;

internal class RewardController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/DailyRewardWindow" };

    private DailyRewardView _dailyRewardView;
    private DailyRewardController _dailyRewardController;

    public RewardController(Transform placeForUi, Profile.ProfilePlayer profilePlayer)
    {
        _dailyRewardView = LoadView(placeForUi);
        _dailyRewardController = new DailyRewardController(_dailyRewardView, profilePlayer);
        _dailyRewardController.RefreshView();
    }

    private DailyRewardView LoadView(Transform placeForUi)
    {
        GameObject objectView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<DailyRewardView>();
    }
}
