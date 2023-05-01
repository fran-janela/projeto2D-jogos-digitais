using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject startScreen;
    public GameObject creditsScreen;
    public GameObject optionsScreen;
    public GameObject instructionsScreen;

    public AudioSource musicSound;
    public AudioSource buttonSound;

    public void PlayButtonSound() {
        musicSound.Play();
    }

    public void PlayClickSound() {
        buttonSound.Play();
    }

    void Start() {
        PlayButtonSound();
    }

    public void StartGame() {
        PlayClickSound();
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenStartGame() {
        PlayClickSound();
        startScreen.SetActive(true);
    }

    public void OpenOptions() {
        PlayClickSound();
        optionsScreen.SetActive(true);
    }

    public void CloseOptions() {
        PlayClickSound();
        optionsScreen.SetActive(false);
    }

    public void OpenCredits() {
        PlayClickSound();
        creditsScreen.SetActive(true);
    }

    public void CloseCredits() {
        PlayClickSound();
        creditsScreen.SetActive(false);
    }

    public void OpenInstructions() {
        PlayClickSound();
        instructionsScreen.SetActive(true);
    }

    public void CloseInstructions() {
        PlayClickSound();
        instructionsScreen.SetActive(false);
    }

    public void QuitGame() {
        PlayClickSound();
        Debug.Log("Quit Game");
        Application.Quit();
    }


}
