using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRandomBehaviourScript : FanBehaviourScript
{

    private Vector3 velocityVector;
    [SerializeField]
    private float velocity;
    public float Velocity
    {
        get
        {
            return velocity;
        }
        set
        {
            velocity = value;
        }
    }
    [SerializeField]
    private float timeChange;
    public float TimeChange
    {
        get
        {
            return timeChange;
        }
        set
        {
            timeChange = value;
        }
    }

    private float elapseTime;

    [SerializeField]
    private bool _rotateToDirection;

    public override void Init()
    {
        elapseTime = 0;
        velocityVector = GetNewVelocityVector();
    }

    public override void Fun(float deltaTime)
    {
        this.elapseTime += deltaTime;
        if (elapseTime > timeChange)
        {
            elapseTime = elapseTime - timeChange;
            velocityVector = GetNewVelocityVector();
        }
        transform.Translate(velocityVector * velocity * deltaTime);
    }

    private Vector3 GetNewVelocityVector()
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        Vector3 end = new Vector3(randomPoint.x, transform.position.y, randomPoint.y);
        Vector3 newDir = end.normalized;

        newDir.Normalize();
        newDir.Set(newDir.x, 0, newDir.z);

        if (_rotateToDirection)
        {
            Animation anim = GetComponentInChildren<Animation>();
            float angle = Vector3.Angle(newDir, anim.transform.forward);
            anim.transform.Rotate(Vector3.up * angle);
        }

        return newDir;
    }

    public override void Cancel()
    {
        base.Cancel();
        velocityVector = Vector3.zero;
        elapseTime = 0;
    }
}
