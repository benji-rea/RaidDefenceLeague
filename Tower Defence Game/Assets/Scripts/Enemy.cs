using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int enemyHealth = 100;
    public int moneyGain = 50;

    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    void Start ()
    {
        target = WaypointManager.points[0];
    }

    public void DamageCalculator (int amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0 )
        {
            DespawnEnemy();
        }
    }

    void DespawnEnemy()
    {
        PlayerAttributes.Money += moneyGain;
        PlayerAttributes.EnemiesKillled ++;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);  
        
        Destroy(gameObject);
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }     
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= WaypointManager.points.Length - 1)
        {

            PathEnd();
            return;
        }

        waypointIndex++;
        target = WaypointManager.points[waypointIndex];
    }

    void PathEnd()
    {
        PlayerAttributes.Health--;
        Destroy(gameObject);
    }
}
