using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillJump : Skill
{

    [SerializeField]
    private Vector3 force;

    private Rigidbody rb;

    // Use this for initialization   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Fun(float elapseTime)
    {
        Debug.Log("Execute Jump");
        var obj = GameObject.FindGameObjectWithTag("Player0" + getPlayerID());
        obj.GetComponentInChildren<Rigidbody>().AddForce(force, ForceMode.Impulse);
        //rb.AddForce(force, ForceMode.Impulse);
    }

    public override bool Active(float newElapseTime2)
    {
        return true;
    }

}
