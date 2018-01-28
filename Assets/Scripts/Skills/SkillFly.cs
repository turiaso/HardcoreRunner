using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFly : Skill
{

    // Use this for initialization 

    [SerializeField]
    private float altura;

    [SerializeField]
    private float scalaSubida;

    [SerializeField]
    private float loopTime;

    [SerializeField]
    private float duration;

    [SerializeField]
    private float elapseTime2;

    private float managePos = 0;

    List<bool> isPlayerActive;

    void Start()
    {
        isPlayerActive = new List<bool>(2);
        isPlayerActive.Add(false);
        isPlayerActive.Add(false);
    }

    public override void Fun(float elapseTime)
    {
        Debug.Log("Execute Fly");
        var player = GameObject.FindGameObjectWithTag("Player0" + getPlayerID());
        player.GetComponentInChildren<Rigidbody>().useGravity = false;
        elapseTime = 0;
        managePos = player.transform.position.y + altura;
        StartCoroutine(Ascensdent(player, managePos));
        isPlayerActive[getPlayerID()] = true;
    }



    public float getelapseTime2()
    {
        return elapseTime2;
    }

    public void setelapseTime2(float newElapseTime2)
    {
        elapseTime2 = newElapseTime2;
    }
    public override bool Active(float newElapseTime2)
    {
        if (!isActive())
        {
            elapseTime2 += newElapseTime2;
            if (elapseTime2 > duration)
            {
                elapseTime2 = 0;
                active = true;
                var player = GameObject.FindGameObjectWithTag("Player0" + getPlayerID());
                managePos = player.transform.position.y - altura;
                StartCoroutine(Descendent(player, managePos));
                elapseTime = 0;
            }
            else
            {
                return false;
            }
        }
        return true;
    }



    private IEnumerator Ascensdent(GameObject player, float managePos)
    {
        while (player.transform.position.y < managePos)
        {
            float newY = player.transform.position.y + scalaSubida;
            if (newY > managePos)
            {
                newY = managePos;
            }
            player.transform.position = new Vector3(player.transform.position.x, newY, player.transform.position.z);
            yield return new WaitForSeconds(loopTime);
        }
    }

    private IEnumerator Descendent(GameObject player, float managePos)
    {
        while (player.transform.position.y > managePos)
        {
            float newY = player.transform.position.y - scalaSubida;
            if (newY < managePos)
            {
                newY = managePos;
            }
            player.transform.position = new Vector3(player.transform.position.x, newY, player.transform.position.z);
            yield return new WaitForSeconds(loopTime);
        }
        player.GetComponentInChildren<Rigidbody>().useGravity = true;

        isPlayerActive[getPlayerID()] = false;
    }

    public override bool isActive()
    {
        return !isPlayerActive[getPlayerID()];
    }
}
