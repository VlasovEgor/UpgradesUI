using UnityEngine;

public abstract class ConveyorUpgradeConfig : UpgradeConfig
{
    public string FactoryId;

    public override abstract Upgrade InstantiateUpgrade();
    
}
