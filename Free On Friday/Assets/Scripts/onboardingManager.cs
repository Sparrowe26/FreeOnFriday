using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onboardingManager : MonoBehaviour
{
    public int primeInt = 0;         // This integer drives game progress!
    [SerializeField] public string nextScene;
    public GameObject nextButton;
    public AudioSource source;
    public AudioClip clip;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    //  private bool allowSpace = true;

    // initial visibility settings. Any new images or buttons need to also be SetActive(false);
    async void Start()
    {
        // DialogueDisplay.SetActive(false);
        // ArtBG1.SetActive(true);
        FadeIn(image1);
        image1.SetActive(true);
        image2.SetActive(false);
        image3.SetActive(false);
    }

    void Update()
    {         // use spacebar as Next button
              // if (allowSpace == true)
        {
            //     if (Input.GetKeyDown("space"))
            {
                //         Next();
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        Next();
    }

    //Story Units! The main story function. Players hit [NEXT] to progress to the next primeInt:
    public void Next()
    {
        //source.PlayOneShot(clip);
        //nextButton.SetActive(true);
        primeInt = primeInt + 1;
        if (primeInt == 1)
        {
            FadeIn(image2);
            image2.SetActive(true);
            //image1.SetActive(true);
            Debug.Log("yuh ran");

            // AudioSource.Play();
        }
        else if (primeInt == 2)
        {
            image3.SetActive(true);
            // DialogueDisplay.SetActive(true);
        }
        else if (primeInt == 3)
        {
            image3.SetActive(true);
            //gameHandler.AddPlayerStat(1);
            // Invoke("ButtonAppear1", 3);
            SceneManager.LoadScene(nextScene);

        }

        //Please do NOT delete this final bracket that ends the Next() function:
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
    public void FadeIn(GameObject fadeImage)
    {

        float alphaLevel = 0;
        fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
        for (int i = 0; i < 100; i++)
        {
            alphaLevel += 0.01f;
            //yield return null;
            fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
            Debug.Log("Alpha is: " + alphaLevel);
        }
    }

    IEnumerator FadeOut(GameObject fadeImage)
    {
        float alphaLevel = 1;
        fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
        for (int i = 0; i < 100; i++)
        {
            alphaLevel -= 0.01f;
            yield return null;
            fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
            Debug.Log("Alpha is: " + alphaLevel);
        }
    }

    public IEnumerator ButtonDisplay()
    {
        nextButton.SetActive(false);
        Debug.Log("waiting...");
        yield return new WaitForSeconds(2f);
        Debug.Log("All done!");

    }

    public void ButtonAppear1()
    {
        Debug.Log("invoked method!");
        nextButton.SetActive(true);
    }
}

