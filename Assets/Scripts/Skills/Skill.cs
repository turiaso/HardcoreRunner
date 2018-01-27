using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string _tagOwner;
    public bool _inCD;
    public bool _inUse;

    private void Awake()
    {
        ResetVars();
    }

    private void ResetVars()
    {
        _inCD = false;
        _inUse = false;
    }

    public void SetInUse(bool inUse)
    {
        _inUse = inUse;
    }

    public bool InUse()
    {
        return _inUse;
    }

    public abstract void Execute();
}
