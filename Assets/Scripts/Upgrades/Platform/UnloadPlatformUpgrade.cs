using UnityEngine;

public class UnloadPlatformUpgrade : Upgrade, IInitGameListener
{
    [SerializeField] private int _upgradeStep;

    private readonly UnloadPlatformUpgradeConfig _upgradeConfig;

    private Conveyor _conveyor;

    public override string CurrentStats
    {
        get { return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public UnloadPlatformUpgrade(UnloadPlatformUpgradeConfig config, Conveyor conveyor) : base(config)
    {
        _upgradeConfig = config;
        _conveyor = conveyor;
    }

    protected override void OnUpgrade(int level)
    {
        var unloadZoneComponent = _conveyor.Get<IUnloadZoneComponent>();
        var amount = _upgradeConfig.PlatformTable.GetAmount(level);
        unloadZoneComponent.MaxValue = amount;
    }

    public void Initialization()
    {
        OnUpgrade(Level);
    }
}