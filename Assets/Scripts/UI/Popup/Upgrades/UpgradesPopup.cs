using System;
using UnityEngine;

public class UpgradesPopup : Popup
{
    [SerializeField] private UpgradeListPresenter upgradeListPresenter;

    protected override void OnShow(object args)
    {
        if (args is not ConveyorIdPopupManagerArgs factoryIdArg)
        {
            throw new Exception("Expected FactoryIdArg!");
        }

        upgradeListPresenter.Show(factoryIdArg.ToString());
    }

    protected override void OnHide()
    {
        upgradeListPresenter.Hide();
    }
}
