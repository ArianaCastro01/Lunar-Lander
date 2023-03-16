using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaCollision : MonoBehaviour
{
    public GameObject GameOverScreen; //Panel object
    public GameObject WinScreen; //Panel object

    public GameObject CrashScreen; // Panel object
    public GameObject Player;

    public bool GameIsPaused = false; //bool to keep track when paused or not
    private void Start()
    {
        Time.timeScale = 1; // Game is not paused
    }

    public void GameOver()
    {
        GameIsPaused = true; // Game is paused
        GameOverScreen.SetActive(true); // GameOver Panel set to true
        Time.timeScale = 0; //Game is paused
    }

    public void Crash()
    {
        GameIsPaused = true; // Game is paused
        CrashScreen.SetActive(true); // Crash Panel set to true
        Time.timeScale = 0; //Game is paused
    }

    public void Win()
    {
        GameIsPaused = true; // Game is paused
        WinScreen.SetActive(true); // Win Panel set to true
        Time.timeScale = 0; // Game is paused
    }

    public void LoadMenu(bool tf)
    {
        Time.timeScale = 1f;
        GameIsPaused = tf;
        SceneManager.LoadScene("Menu"); // Loads Menu scene
    }
    /*public void QuitGame(bool tf)
    {
        GameOverScreen.SetActive(false); // GameOver Panel set to false
        GameIsPaused = tf;
        Application.Quit(); // Exit Game
    }*/

    public void Restart(bool tf)
    {
        Time.timeScale = 1f;
        GameIsPaused = tf;
        SceneManager.LoadScene("Game"); // Reloads current scene
        GameOverScreen.SetActive(false); // GameOver Panel set to false
    }
}

