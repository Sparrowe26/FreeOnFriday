using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load Game into the first level
    private string nextSceneTitle = "Onboarding";
    private string firstScene = "MainMenu";
    private string gameOver = "GameOver";
    private string controls = "Controls";
    public void Play()
    {
        SceneManager.LoadScene(nextSceneTitle);
    }

    public void Return()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOver);
    }

    public void Controls()
    {
        SceneManager.LoadScene(controls);
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
    }
}
