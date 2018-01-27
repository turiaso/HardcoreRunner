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

    private void Start()
    {
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

    public void ClickInExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPaused = false;
#else
        UnityEngine.Application.Quit();
#endif
    }

    private void ShowMainMenu()
    {
        _playObj.gameObject.SetActive(false);
        _creditsObj.gameObject.SetActive(false);
        _mainMenuObj.gameObject.SetActive(true);
    }

    private void ShowPlayGameMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        return;

        _playObj.gameObject.SetActive(true);
        _creditsObj.gameObject.SetActive(false);
        _mainMenuObj.gameObject.SetActive(false);
    }
    private void ShowCreditMenu()
    {
        _playObj.gameObject.SetActive(false);
        _creditsObj.gameObject.SetActive(true);
        _mainMenuObj.gameObject.SetActive(false);
    }
}
