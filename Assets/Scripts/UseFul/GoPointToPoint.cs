using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPointToPoint : MonoBehaviour
{

    public enum type
    {
        Loop,
        Once
    }

    public type _type;

    List<GoPointToPointInfo> _listWaypoint;
    int currentWayPoint = 0;

    public void Start()
    {
        transform.position = _listWaypoint[0].position.position;

        CheckNextPoint();

    }

    private void CheckNextPoint()
    {
        Vector3 originalPos = Vector3.zero; ;
        Vector3 finalPos = Vector3.zero;

        ++currentWayPoint;

        if (currentWayPoint >= _listWaypoint.Count)
        {
            if (_type == type.Loop)
            {
                currentWayPoint = 0;
                originalPos = transform.position;
                finalPos = _listWaypoint[0].position.position;
            }
        }
        else
        {
            originalPos = transform.position;
            finalPos = _listWaypoint[currentWayPoint].position.position;
        }

        StartCoroutine(GoToNextPoint(originalPos, finalPos));
    }

    private IEnumerator GoToNextPoint(Vector3 origin, Vector3 final)
    {

        float timestamp = 0;
        while (timestamp < _listWaypoint[currentWayPoint].time)
        {
            timestamp += Time.deltaTime;

            transform.position = Vector3.Lerp(origin, final, timestamp / _listWaypoint[currentWayPoint].time);
            yield return 0;
        }
        yield return 0;

        CheckNextPoint();
    }
}
