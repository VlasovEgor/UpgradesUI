using UnityEngine;
using Zenject;

[CreateAssetMenu(
       fileName = "CreationSpeedConfig",
       menuName = "Upgrade/New LoadCreationSpeedConfig"
   )]
public class CreationSpeedUpgradeConfig : ConveyorUpgradeConfig
{
    [SerializeField] public CreationSpeedTable CreationSpeedTable;

    public override Upgrade InstantiateUpgrade()
    {
        var gameContext = FindObjectOfType<GameContext>(); //crutch
        var conveyor = gameContext.GetService<ConveyorCatalog>().GetConveyor(FactoryId);

        var creationSpeedUpgrade = new CreationSpeedUpgrade(this, conveyor);
       // gameContext.AddListener(creationSpeedUpgrade);

        return creationSpeedUpgrade;
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        CreationSpeedTable.OnValidate(MaxLevel);
    }
}
