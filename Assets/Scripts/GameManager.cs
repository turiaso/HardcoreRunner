using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        LoadLevelsUnlock();
    }

    private void LoadLevelsUnlock()
    {
        LastLevelUnlock = PlayerPrefs.GetInt(LevelUnlock, 1);
    }
}
