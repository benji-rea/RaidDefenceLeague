using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeManager : MonoBehaviour
{
    public Color selectColor;
    public Color insufficientFundsColor;
    public Vector3 positionOffset;
    
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {      
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        //safety checks on click if things can be done
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        //passes itself onto  the build manager to let it know where to place it
        // buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerAttributes.Money < blueprint.cost)
        {
            Debug.Log("Insufficient Funds");
            return;
        }

        PlayerAttributes.Money -= blueprint.cost;
        PlayerAttributes.MoneySpend += blueprint.cost;

        turretBlueprint = blueprint; 

        //Turret Builder
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPos(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Built");
    }

    public void UpgradeTurret()
    {
        if (PlayerAttributes.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Insufficient Funds");
            return;
        }

        PlayerAttributes.Money -= turretBlueprint.upgradeCost;
        PlayerAttributes.MoneySpend += turretBlueprint.upgradeCost;

        //Turret Destroyer
        Destroy(turret);

        //Turret Upgrader
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPos(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }

    public void SellTurret()
    {
        PlayerAttributes.Money += turretBlueprint.GetSellValue();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        
        turretBlueprint = null;
        isUpgraded = false;
        
        Debug.Log("Turret Sold!");
    }

    private void OnMouseEnter()
    {
        //checks to see when hobering if anything can be done
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.FundsAvailable)
        {
            rend.material.color = selectColor;
        }
        else
        {
            rend.material.color = insufficientFundsColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
