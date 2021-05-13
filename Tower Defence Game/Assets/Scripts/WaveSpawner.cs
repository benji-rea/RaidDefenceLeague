using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float waveTimer = 5f;
    private float countdown = 2f;

    public Text waveCountdownTimer;
    public Text waveIndexText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = waveTimer;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = "Time Remaining: " + string.Format("{0:00.00}", countdown);
        //waveCountdownTimer.text = Mathf.Ceil(countdown).ToString();
        waveIndexText.text = "Wave: " + waveIndex;

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerAttributes.Waves++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
             
        Debug.Log("Wave Spawned");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }    
}
