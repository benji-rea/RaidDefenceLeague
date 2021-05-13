using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static int Money; //accessible without an instance
    public int startMoney = 300;//accessible in the editor


    public static int Health;
    public int startHealth = 20;

    public static int MoneySpend;
    public static int Waves;
    public static int EnemiesKillled;

    void Start()
    {
        Money = startMoney;
        Health = startHealth;
        
        MoneySpend = 0;
        Waves = 0;
        EnemiesKillled = 0;
    }

}
