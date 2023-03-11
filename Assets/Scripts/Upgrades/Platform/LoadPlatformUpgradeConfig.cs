using UnityEngine;

[CreateAssetMenu(
       fileName = "PlatformsUpgradeConfig",
       menuName = "Upgrade/New LoadPlatformsUpgradeConfig"
   )]
public class LoadPlatformUpgradeConfig : ConveyorUpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable PlatformTable;

    public override Upgrade InstantiateUpgrade()
    {
        var gameContext = FindObjectOfType<GameContext>(); //crutch
        var conveyor = gameContext.GetService<ConveyorCatalog>().GetConveyor(FactoryId);

        var loadPlatformUpgrade = new LoadPlatformUpgrade(this, conveyor);
        //gameContext.AddListener(loadPlatformUpgrade);

        return loadPlatformUpgrade;
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        PlatformTable.OnValidate(MaxLevel);
    }
}

