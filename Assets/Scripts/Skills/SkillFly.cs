using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFly : Skill
{

    // Use this for initialization 

    [SerializeField]
    private float altura;

    [SerializeField]
    private float duration;

    [SerializeField]
    private float elapseTime2;


    void Start()
    {
    }

    public override void Fun(float elapseTime)
    {
        Debug.Log("Execute Jump");
        var player = GameObject.FindGameObjectWithTag("Player0" + getPlayerID());
        player.GetComponentInChildren<Rigidbody>().useGravity = false;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + altura, player.transform.position.z);
        elapseTime = 0;
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
                player.GetComponentInChildren<Rigidbody>().useGravity = true;            
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - altura, player.transform.position.z);
                elapseTime = 0;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

}
