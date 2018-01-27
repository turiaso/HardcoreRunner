using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLinearBehaviourScript : FanBehaviourScript
{

    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private float timeChange;
    [SerializeField]
    private bool _rotateToDirection;

    Animation _anim;

    public override void Init()
    {
        if (_rotateToDirection)
        {
            _anim = GetComponentInChildren<Animation>();
            float angle = Vector3.Angle(_anim.transform.forward, velocity.normalized);
            _anim.transform.Rotate(Vector3.up * angle);
        }
    }
    private float elapseTime;

    public override void Fun(float deltaTime)
    {
        this.elapseTime += deltaTime;
        if (elapseTime > timeChange)
        {
            elapseTime = elapseTime - timeChange;
            velocity = -velocity;
            if (_rotateToDirection)
                _anim.transform.Rotate(Vector3.up * 180);

        }
        transform.Translate(velocity * deltaTime);


    }
}
