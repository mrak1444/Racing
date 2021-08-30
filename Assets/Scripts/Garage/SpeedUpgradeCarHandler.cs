public class SpeedUpgradeCarHandler : IUpgradeCarHandler
{

    private float _speed;

    public SpeedUpgradeCarHandler(float speed)
    {
        _speed = speed;
    }

    public void Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Speed = _speed;
    }
}