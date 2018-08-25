using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject storyCanvas;
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public GameObject howToPlayCanvas;


    public AudioClip quitSound;
    public AudioClip storySound;
    public AudioClip startSound;
    public AudioClip creditSound;
    public AudioClip howToPlaySound;
    AudioSource source;

    // Use this for initialization
    void Start ()
    {
        mainMenuCanvas.SetActive(true);
        storyCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        howToPlayCanvas.SetActive(false);

        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        source.PlayOneShot(startSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Story()
    {
        storyCanvas.SetActive(true);
        source.PlayOneShot(storySound);
    }

    public void CloseStory()
    {
        storyCanvas.SetActive(false);
    }

    public void HowToPlay()
    {
        howToPlayCanvas.SetActive(true);
        source.PlayOneShot(howToPlaySound);
    }

    public void CloseHowToPlay()
    {
        howToPlayCanvas.SetActive(false);
    }

    public void Credits()
    {
        creditsCanvas.SetActive(true);
        source.PlayOneShot(creditSound);
    }

    public void CloseCredits()
    {
        creditsCanvas.SetActive(false);
    }

    public void Quit()
    {
        source.PlayOneShot(quitSound);
        Application.Quit();
    }
}
