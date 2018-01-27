using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLinearBehaviourScript:FanBehaviourScript{

    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private float timeChange;

    private float elapseTime;

    public override void Fun(float deltaTime)
    {
        this.elapseTime += deltaTime;
        if (elapseTime > timeChange)
        {
            elapseTime = elapseTime - timeChange;
            velocity = -velocity;
        }
        transform.Translate(velocity * deltaTime);
    }
}
