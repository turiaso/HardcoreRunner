using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    public int playerID;
    [SerializeField]
    public float coolDown;
    public float elapseTime = 0;

    public bool active = true;

    // Update is called once per frame
    void Update()
    {
        if (elapseTime < coolDown)
        {
            elapseTime += Time.deltaTime;

            if (elapseTime >= coolDown)
            {
                elapseTime = coolDown;
                active = true;
            }

        }
    }


    public void Execute(float deltaTime)
    {
        elapseTime = 0;
        active = false;
        Fun(deltaTime);
    }

    public abstract void Fun(float deltaTime);
    public abstract bool Active(float newElapseTime2);

    public void setPlayerID(int id)
    {
        playerID = id;
    }

    public int getPlayerID()
    {
        return playerID;
    }

    public abstract bool isActive();


    internal bool isReady()
    {
        return !isActive() && elapseTime < coolDown;
    }
}
