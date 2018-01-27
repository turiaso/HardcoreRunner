using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga:Skill{

    [SerializeField]
    private Vector3 force;

    private Rigidbody rb;

    // Use this for initialization   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Fun(float deltaTime)
    {
        rb.AddForce(force, ForceMode.Impulse);
    }
}
