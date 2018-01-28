using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga : Skill
{

    [SerializeField]
    private int force;

    private Rigidbody rb;

    // Use this for initialization   
    void Start()
    {

    }

    public override void Fun(float elapseTime)
    {
        rb = GameObject.FindGameObjectWithTag("Player0" + getPlayerID()).GetComponentInChildren<Rigidbody>();
        Debug.Log("Execute Carga");
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
    public override bool Active(float newElapseTime2)
    {
        return true;
    }

    public override bool isActive()
    {
        return active;
    }
}
