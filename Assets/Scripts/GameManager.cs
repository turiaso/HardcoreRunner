using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private const string LevelUnlock = "Level";
    public int LastLevelUnlock
    {
        get; set;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnLoadScene;
        LoadLevelsUnlock();
    }

    private void OnLoadScene(Scene scene, LoadSceneMode arg1)
    {
        if (scene.buildIndex >= 3)
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }


    private void LoadLevelsUnlock()
    {
        LastLevelUnlock = PlayerPrefs.GetInt(LevelUnlock, 1);
    }
}
