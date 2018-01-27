using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTotallyRandomBehavior : FanScript
{
    public List<AnimationClip> _allAnimations;
    [SerializeField]
    public float _maxSpeed;
    [SerializeField]
    public float _minSpeed;

    [SerializeField]
    public float _minSpeedToChange;
    [SerializeField]
    public float _maxSpeedToChange;

    public void Start()
    {
        GenerateRandom();
    }

    private void GenerateRandom()
    {
        float timeToChange = UnityEngine.Random.Range(_minSpeedToChange, _maxSpeedToChange);

        int behavior = UnityEngine.Random.Range(0, 2);

        if (fanBehaviourScript != null)
            fanBehaviourScript.Cancel();
        if (behavior == 0)
        {
            FanLinearBehaviourScript behaviorLinear = GetComponent<FanLinearBehaviourScript>();
            fanBehaviourScript = behaviorLinear;

            behaviorLinear.Velocity = new Vector3(UnityEngine.Random.Range(-_maxSpeed, _maxSpeed), 0, UnityEngine.Random.Range(-_maxSpeed, _maxSpeed));
            behaviorLinear.TimeChange = timeToChange;

            behaviorLinear.Init();
        }
        else
        {
            FanRandomBehaviourScript behaviorLinear = GetComponent<FanRandomBehaviourScript>();
            fanBehaviourScript = behaviorLinear;

            behaviorLinear.Velocity = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
            behaviorLinear.TimeChange = timeToChange;

            behaviorLinear.Init();
        }


        int randomAnim = UnityEngine.Random.Range(0, _allAnimations.Count);
        GetComponentInChildren<Animation>().AddClip(_allAnimations[randomAnim], _allAnimations[randomAnim].name);
        GetComponentInChildren<Animation>().clip = _allAnimations[randomAnim];
        GetComponentInChildren<Animation>().Play();
        StartCoroutine(ChangeRandom(randomAnim));
    }

    private IEnumerator ChangeRandom(int randomAnim)
    {
        yield return new WaitForSeconds(randomAnim - 0.1f);

        GenerateRandom();
    }
}
