using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load Game into the first level
    public string nextSceneTitle;
    public void Play()
    {
        SceneManager.LoadScene(nextSceneTitle);
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
    }
}
