using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// GameManager with all methods needed to be present between scenes


public class GameManager : MonoBehaviour
{
    private static bool created = false;
    
    private bool isPaused;

    private void Awake()
    {


        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

   


    private void Update()
    {
        //EscapePressed();
        CheckGameOver();



    }

    private string CheckScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    private void CheckGameOver()
    {
        if(Input.touchCount > 0 && 
           CheckScene() == "3_GameOver")
        {
            RestartGame();
        }

    }


    private void EscapePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "1_StartGame")
            {
                EndGame();
            }

            if (currentScene == "2_MainGame" ||
               currentScene == "3_GameOver")
            {
                RestartGame();

            }

        }
    }

    public void StartGame()
    {
        isPaused = false;
        SceneManager.LoadScene("2_MainGame");
    }

    public void RestartGame()
    {
        isPaused = false;
        SceneManager.LoadScene("1_StartGame");
    }

    public void LoseGame()
    {
        isPaused = false;
        SceneManager.LoadScene("3_GameOver");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    //If the game is paused, objects in scene will be prevented from interacting
    public void PauseGame()
    {
        isPaused = true;
    }

    //Check if the game is paused from other objects
    public bool IsPausedGame()
    {
        return isPaused;
    }


    

    
}


