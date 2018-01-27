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

    private bool active = true;

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


    public void Execute()
    {
        elapseTime = 0;
        active = false;
        Fun();
    }

    public abstract void Fun();

    public void setPlayerID(int id)
    {
        playerID = id;
    }

    public int getPlayerID()
    {
        return playerID;
    }

    public bool isActive()
    {
        return active;
    }

}
