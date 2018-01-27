using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GUIMainMenu : MonoBehaviour
{

    public GameObject _mainMenuObj;
    public GameObject _playObj;
    public GameObject _creditsObj;
    public GameObject _howToPlay;

    private void Start()
    {
        _howToPlay.gameObject.SetActive(false);
        _playObj.gameObject.SetActive(false);
        _creditsObj.gameObject.SetActive(false);
    }

    public void ClickInPlayGame()
    {
        ShowPlayGameMenu();
    }

    public void ClickInCredits()
    {
        ShowCreditMenu();
    }

    public void ClickInHowToPlay()
    {
        ShowHowToPlay();
    }

    public void ClickInExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPaused = false;
#else
        UnityEngine.Application.Quit();
#endif
    }

    public void ShowMainMenu()
    {
        _playObj.gameObject.SetActive(false);
        _creditsObj.gameObject.SetActive(false);
        _mainMenuObj.gameObject.SetActive(true);
        _howToPlay.gameObject.SetActive(false);
    }

    private void ShowPlayGameMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        return;

        _playObj.gameObject.SetActive(true);
        _creditsObj.gameObject.SetActive(false);
        _mainMenuObj.gameObject.SetActive(false);
        _howToPlay.gameObject.SetActive(false);
    }
    private void ShowCreditMenu()
    {
        _playObj.gameObject.SetActive(false);
        _creditsObj.gameObject.SetActive(true);
        _mainMenuObj.gameObject.SetActive(false);
        _howToPlay.gameObject.SetActive(false);
    }

    private void ShowHowToPlay()
    {
        _howToPlay.gameObject.SetActive(true);
        _playObj.gameObject.SetActive(false);
        _creditsObj.gameObject.SetActive(false);
        _mainMenuObj.gameObject.SetActive(false);
    }
}
