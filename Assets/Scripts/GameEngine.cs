using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

    [SerializeField]
    GameObject uiCanvas;
    [SerializeField]
    GameObject winCanvas;
    [SerializeField]
    GameObject deathCanvas;

    public Fan[] interactableObjects;
    string[] characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	// Use this for initialization
	void Start () {
        RestartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        //Start the game in a frozen state
        Freeze();
        ResetFanKeys();
        winCanvas.SetActive(false);
        deathCanvas.SetActive(false);
    }

    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Freeze()
    {
        Time.timeScale = 0.0f;
        uiCanvas.SetActive(true);
    }

    public void Unfreeze()
    { 
        Time.timeScale = 1.0f;
        uiCanvas.SetActive(false);
    }

    public void ShowWinScreen()
    {
        winCanvas.SetActive(true);
    }

    public void ShowDeathScreen()
    {
        deathCanvas.SetActive(true);
    }

    void ResetFanKeys()
    {
        List<string> keysTaken = new List<string>();
        foreach (Fan interactableObject in interactableObjects)
        {
            bool validCharAdded = false;
            while (!validCharAdded)
            {
                bool characterTaken = false;
                string randomChar = characters[Random.Range(0, characters.Length)];
                foreach (string character in keysTaken)
                {
                    if (character == randomChar)
                    {
                        characterTaken = true;
                    }
                }

                if (!characterTaken)
                {
                    interactableObject.ChangeLetter(randomChar);
                    keysTaken.Add(randomChar);
                    validCharAdded = true;
                }
            }
            
        }
    }
}
