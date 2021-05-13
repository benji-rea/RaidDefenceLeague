using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]// Unity will save and load values created in this class, to enable inspector editing
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellValue()
    {
        return cost / 2;
    }
}
