using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRandomBehaviourScript : FanBehaviourScript{
    
    private Vector3 velocityVector;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float timeChange;

    private float elapseTime;

    public override void Fun(float deltaTime)
    {
        this.elapseTime += deltaTime;
        if (elapseTime > timeChange)
        {
            elapseTime = elapseTime - timeChange;
            Vector2 randomPoint = Random.insideUnitCircle;
            Vector3 end = new Vector3(randomPoint.x, transform.position.y, randomPoint.y);
            velocityVector = end - transform.position;

        }
        transform.Translate(velocityVector.normalized * velocity * deltaTime );
    }
}
