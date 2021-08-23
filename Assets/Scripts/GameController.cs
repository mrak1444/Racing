using Game.InputLogic;
using Profile;
using Tools;
using UnityEngine;

internal class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var leftMove = new SubscriptionProperty<float>();
        var rightMove = new SubscriptionProperty<float>();
        var _inputGameController = new InputGameController(leftMove, rightMove, profilePlayer.CurrentCar);
        var _backgroundController = new BackgroundController(leftMove, rightMove);
        var _carController = new CarController();
    }
}
