using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text wavesText;
    public Text moneyText;
    public Text enemiesText;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public string menuScene = "MainMenu";

    public SceneFader sceneFader;

    private void OnEnable()
    {
        wavesText.text = PlayerAttributes.Waves.ToString();
        moneyText.text = "$" + PlayerAttributes.MoneySpend;
        enemiesText.text = PlayerAttributes.EnemiesKillled.ToString();
    }

    public void Retry()
    {
        PlayClick();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        PlayClick();
        sceneFader.FadeTo(menuScene);
    }

    private void PlayClick()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
