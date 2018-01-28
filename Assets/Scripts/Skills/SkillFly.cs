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

    private GameObject managePlayer = null;
    private float managePos = 0;


    void Start()
    {
    }

    public override void Fun(float elapseTime)
    {
        Debug.Log("Execute Fly");
        var player = GameObject.FindGameObjectWithTag("Player0" + getPlayerID());
        player.GetComponentInChildren<Rigidbody>().useGravity = false;
        elapseTime = 0;
        managePlayer = player;
        managePos = player.transform.position.y + altura;
        StartCoroutine("Ascensdent");
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
        if (!isActive() )
        {
            elapseTime2 += newElapseTime2;
            if (elapseTime2 > duration)
            {
                elapseTime2 = 0;
                active = true;
                var player = GameObject.FindGameObjectWithTag("Player0" + getPlayerID());
                managePlayer = player;
                managePos = player.transform.position.y - altura;
                StartCoroutine("Descendent");
                elapseTime = 0;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator Ascensdent()
    {
        while (managePlayer.transform.position.y < managePos)
        {
            float newY = managePlayer.transform.position.y + scalaSubida;
            if (newY > managePos)
            {
                newY = managePos;
            }
            managePlayer.transform.position = new Vector3(managePlayer.transform.position.x, newY, managePlayer.transform.position.z);
            yield return new WaitForSeconds(loopTime);
        }
    }

    IEnumerator Descendent()
    {
        while (managePlayer.transform.position.y > managePos)
        {
            float newY = managePlayer.transform.position.y - scalaSubida;
            if (newY < managePos)
            {
                newY = managePos;
            }
            managePlayer.transform.position = new Vector3(managePlayer.transform.position.x, newY, managePlayer.transform.position.z);
            yield return new WaitForSeconds(loopTime);
        }
        managePlayer.GetComponentInChildren<Rigidbody>().useGravity = true;
    }

}
