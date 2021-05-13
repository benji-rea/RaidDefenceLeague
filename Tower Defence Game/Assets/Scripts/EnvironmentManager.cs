using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static bool gameIsEnd;

    public GameObject GameOverUI;

    void Start()
    {
        gameIsEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsEnd == true)
            return;

        if (Input.GetKeyDown("e"))
        {
            GameOver();
        }

        if (PlayerAttributes.Health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameIsEnd = true;

        GameOverUI.SetActive(true);
        Debug.Log("Game Over Man! Game Over!");
    }
}
