using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Build Manager in Scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject sniperTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private NodeManager selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null; //Property to "get" the state of turret to build, not to edit it.
        }
    }

    public bool FundsAvailable
    {
        get
        {
            return PlayerAttributes.Money >= turretToBuild.cost; //Property to "get" if the player has enough money and not to edit it.
        }
    }


    public void SelectNode(NodeManager node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    //Sets the turret  to build by checking the prefabs
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
