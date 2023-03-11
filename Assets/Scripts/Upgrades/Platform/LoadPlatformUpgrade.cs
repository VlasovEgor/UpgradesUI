
public class LoadPlatformUpgrade : Upgrade, IInitGameListener
{   
    private readonly LoadPlatformUpgradeConfig _upgradeConfig;
    private Conveyor _conveyor;

    public override string CurrentStats
    {
        get { return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public LoadPlatformUpgrade(LoadPlatformUpgradeConfig config, Conveyor conveyor) : base(config)
    {
        _upgradeConfig = config;
        _conveyor = conveyor;
    }

    protected override void OnUpgrade(int level)
    {
        var factoryStorages = _conveyor.Get<IFactoryStoragesComponent>();
        var amount = _upgradeConfig.PlatformTable.GetAmount(level);

        factoryStorages.SetupMaxValueAllStorages(amount);
    }

    public void Initialization()
    {
        OnUpgrade(Level);
    }
}