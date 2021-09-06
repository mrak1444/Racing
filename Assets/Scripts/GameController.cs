using Game.InputLogic;
using Profile;
using Tools;

internal class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var leftMove = new SubscriptionProperty<float>();
        var rightMove = new SubscriptionProperty<float>();
        var _inputGameController = new InputGameController(leftMove, rightMove, profilePlayer.CurrentCar);
        AddController(_inputGameController);
        var _backgroundController = new BackgroundController(leftMove, rightMove);
        AddController(_backgroundController);
        var _carController = new CarController(profilePlayer.CurrentCar);
        AddController(_carController);
    }
}
