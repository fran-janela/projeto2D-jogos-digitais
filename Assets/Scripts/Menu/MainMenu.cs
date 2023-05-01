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

    public void PlayButtonSound() {
        musicSound.Play();
    }

    void Start() {
        PlayButtonSound();
    }

    public void StartGame() {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenStartGame() {
        startScreen.SetActive(true);
    }

    public void OpenOptions() {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions() {
        optionsScreen.SetActive(false);
    }

    public void OpenCredits() {
        creditsScreen.SetActive(true);
    }

    public void CloseCredits() {
        creditsScreen.SetActive(false);
    }

    public void OpenInstructions() {
        instructionsScreen.SetActive(true);
    }

    public void CloseInstructions() {
        instructionsScreen.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("Quit Game");
        Application.Quit();
    }


}
