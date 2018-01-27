using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAnimation : MonoBehaviour
{

    [SerializeField]
    private bool _rotate180;
    [SerializeField]
    private float _timeToRotate180;

    [SerializeField]
    private AnimationClip _animationClip;
    private Animation _animation;

    private float _timestamp;


    private void Start()
    {
        _animation = GetComponentInChildren<Animation>();
        _animation.AddClip(_animationClip, _animation.name);
        _animation.Play();
    }

    private void Update()
    {
        if (!_rotate180)
            return;

        _timestamp += _timestamp;

        if (_timestamp > _timeToRotate180)
        {
            transform.Rotate(Vector3.up * 180);
            _timestamp = 0;
        }
    }
}
