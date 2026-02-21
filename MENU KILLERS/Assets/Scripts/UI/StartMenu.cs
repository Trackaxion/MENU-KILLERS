using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject titleMenu;
    public GameObject loadMenu;
    public GameObject settingsMenu;
    public GameObject controlsMenu;
    public GameObject audioMenu;
    public GameObject videoMenu;
    public void LoadGame()
    {
        titleMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        titleMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Audio()
    {
        settingsMenu.SetActive(false);
        audioMenu.SetActive(true);
    }

    public void Video()
    {
        settingsMenu.SetActive(false);
        videoMenu.SetActive(true);
    }

    public void LoadBack()
    {
        loadMenu.SetActive(false);
        titleMenu.SetActive(true);
    }

    public void SettingsBack()
    {
        settingsMenu.SetActive(false);
        titleMenu.SetActive(true);
    }

    public void AudioBack()
    {
        audioMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void VideoBack()
    {
        videoMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ControlsBack()
    {
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
