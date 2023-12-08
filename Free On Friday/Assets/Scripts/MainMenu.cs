using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load Game into the first level
    public string nextSceneTitle = "Onboarding";
    public string firstScene = "MainMenu";
    public void Play()
    {
        SceneManager.LoadScene(nextSceneTitle);
    }

    public void Return()
    {
        SceneManager.LoadScene(firstScene);
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
    }
}
