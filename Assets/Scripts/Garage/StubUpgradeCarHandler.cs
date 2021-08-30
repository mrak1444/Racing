public class StubUpgradeCarHandler : IUpgradeCarHandler
{
    public static IUpgradeCarHandler Default = new StubUpgradeCarHandler();

    public void Upgrade(IUpgradableCar upgradableCar)
    {
        Default = (IUpgradeCarHandler)upgradableCar;
    }
}