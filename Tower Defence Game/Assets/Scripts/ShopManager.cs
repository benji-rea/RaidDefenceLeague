using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint sniperTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    //Methods called on Click
    public void SelectStandard()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectSniper()
    {
        Debug.Log("Sniper Turret Selected");
        buildManager.SelectTurretToBuild(sniperTurret);
    }

    public void SelectMissile()
    {
        Debug.Log("Missile Launcher Selecteed");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
