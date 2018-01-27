using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void VoidDelegateVoid();
public delegate void VoidDelegateBool(bool sucess);

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private float _timeLimit;


    private bool _isLevelStart;
    private float _timeStamp;

    public event VoidDelegateVoid OnLevelStart;
    public event VoidDelegateBool OnLevelFinish;

    void Start()
    {
        StartLevel();
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

    public bool IsLevelStart()
    {
        return _isLevelStart;
    }

    public void StartLevel()
    {
        if (OnLevelStart != null) OnLevelStart();
        _isLevelStart = true;
    }

    public void FinishLevel(bool success)
    {
        if (OnLevelFinish != null) OnLevelFinish(success);
        _isLevelStart = false;
    }
}
