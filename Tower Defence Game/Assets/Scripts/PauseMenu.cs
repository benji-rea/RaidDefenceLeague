using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public string menuScene = "MainMenu";

    public SceneFader sceneFader;

    public AudioSource audioSource;
    public AudioClip audioClip;

    void Update()
    {
        if (EnvironmentManager.gameIsEnd == true)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        PlayClick();
        Toggle();    
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        PlayClick();
        Toggle();
        sceneFader.FadeTo(menuScene);
    }
    private void PlayClick()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
