using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    private GameManager gameManager;
    public static bool gameOver;
    public static bool gameStarted;

    void Start()
    {
        gameOver = gameStarted = false;
    }

    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Welcome Back");
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
