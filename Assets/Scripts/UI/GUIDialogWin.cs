using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDialogWin : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
        LevelManager.Instance.OnLevelFinish += OnLevelFinish;
    }

    private void OnLevelFinish(bool sucess)
    {
        if (sucess)
            Show();
    }

    public void Show()
    {

        gameObject.SetActive(true);
    }

    public void ClickInPlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    } // ClickInPlayAgain

    public void ClickInReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    } // ClickInReturnToMainMenu
}
