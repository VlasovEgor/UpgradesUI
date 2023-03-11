using UnityEngine;

public class CreationSpeedUpgrade : Upgrade, IInitGameListener
{
    [SerializeField] private int _upgradeStep;

    private readonly CreationSpeedUpgradeConfig _upgradeConfig;
    private Conveyor _conveyor;

    public override string CurrentStats
    {
        get
        {
            return _upgradeConfig.CreationSpeedTable.GetAmount(Level).ToString();
        }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.CreationSpeedTable.UpgradeStep.ToString(); }
    }

    public CreationSpeedUpgrade(CreationSpeedUpgradeConfig config, Conveyor conveyor) : base(config) 
    { 
        _upgradeConfig = config; 
        _conveyor = conveyor; 
    }

    protected override void OnUpgrade(int level)
    {
        var timeMultiplicationComponent = _conveyor.Get<ITimeMultiplicationComponent>();
        var amount = _upgradeConfig.CreationSpeedTable.GetAmount(level);
        timeMultiplicationComponent.SetMultiplier(amount);
    }

    public void Initialization()
    {
        OnUpgrade(Level);
    }
}