using UnityEngine;

[CreateAssetMenu(
       fileName = "PlatformUpgradeConfig",
       menuName = "Upgrade/New UnloadPlatformUpgradeConfig"
   )]
public class UnloadPlatformUpgradeConfig: ConveyorUpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable PlatformTable;

    public override Upgrade InstantiateUpgrade()
    {   
        var gameContext = FindObjectOfType<GameContext>(); //crutch
        var conveyor = gameContext.GetService<ConveyorCatalog>().GetConveyor(FactoryId);

        var unloadPlatformUpgrade = new UnloadPlatformUpgrade(this, conveyor);
        //gameContext.AddListener(unloadPlatformUpgrade);

        return unloadPlatformUpgrade;
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        PlatformTable.OnValidate(MaxLevel);
    }
}
