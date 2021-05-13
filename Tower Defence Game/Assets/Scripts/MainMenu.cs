using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject guideUI;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public SceneFader sceneFader;
    public string levelToLoad = "MainLevel";

    public void Play()
    {
        PlayClick();

        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit() 
    {
        PlayClick();

        Debug.Log("Quitting");
        Application.Quit();
    }
    public void ToggleGuide()
    {
        PlayClick();
        menuUI.SetActive(!menuUI.activeSelf);
        guideUI.SetActive(!guideUI.activeSelf);
    }

    public void ReturnToMenu()
    {
        PlayClick();
        guideUI.SetActive(false);
        menuUI.SetActive(true);
    }

    private void PlayClick()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
