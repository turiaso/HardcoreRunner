using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoController : MonoBehaviour
{

    public float _pogoSpeedMin;
    public float _pogoSpeedMax;

    public float _radiusAtraction;
    public float _radius;

    // Use this for initialization
    void Start()
    {

    }

    public void Init(float radius)
    {
        var allFansInsidePogo = Physics.OverlapSphere(transform.position, _radiusAtraction, LayerMask.NameToLayer("Fan"), QueryTriggerInteraction.Collide);

        SetMovementToMiddle(allFansInsidePogo);
    }

    private void SetMovementToMiddle(Collider[] allFansInsidePogo)
    {
        Vector3 direction;
        float timeToReach;
        FanLinearBehaviourScript fan;
        FanScript fanBehavior;


        for (int i = allFansInsidePogo.Length - 1; i >= 0; --i)
        {
            direction = CalculateDireccionToTheCenter(allFansInsidePogo[i]);
            timeToReach = UnityEngine.Random.Range(_pogoSpeedMin, _pogoSpeedMax);
            direction = ( direction.magnitude / timeToReach ) * direction.normalized;

            fan = allFansInsidePogo[i].gameObject.GetComponent<FanLinearBehaviourScript>();
            fan.Velocity = direction;
            fan.TimeChange = timeToReach;

            fanBehavior = allFansInsidePogo[i].gameObject.GetComponent<FanScript>();
            if (fanBehavior.FanBehaviorScript != null) fanBehavior.FanBehaviorScript.Cancel();

            fanBehavior.FanBehaviorScript = fan;
            fan.Init();


        }
    }

    private Vector3 CalculateDireccionToTheCenter(Collider fansCollider)
    {
        return transform.position - fansCollider.transform.position;
    }
}
