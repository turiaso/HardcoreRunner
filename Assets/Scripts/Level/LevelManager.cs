using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private float _timeLimit;


    private bool _isLevelStart;
    private float _timeStamp;

    void Start()
    {

    }

    void Update()
    {
        if (_isLevelStart)
        {
            _timeStamp += Time.deltaTime;
            if (_timeStamp > _timeLimit)
            {
                FinishLevel(false);
            }
        }
    }

    public void StartLevel()
    {

    }

    public void FinishLevel(bool success)
    {

    }
}
