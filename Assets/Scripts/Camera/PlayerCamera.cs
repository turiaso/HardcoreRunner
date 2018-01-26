using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollowPlayer : MonoBehaviour
{

    public string _tagPlayer;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _rotationAngle;

    [SerializeField]
    private Vector3 _offset;
    public Vector3 Offset
    {
        get
        {
            return _offset;
        }
        set
        {
            _offset = value;
        }
    }

    void Start()
    {
        GetPlayer();
    }

    private void GetPlayer()
    {
        if (_player == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag(_tagPlayer);
            if (go != null)
            {
                _player = go.transform;
            }
        }
    }

    void Update()
    {
        if (_player == null)
        {
            GetPlayer();
        }

        if (_player == null)
        {
            return;
        }

        SetPosition();
    }

    private void SetCamera()
    {
        transform.rotation = Quaternion.Euler(Vector3.right * _rotationAngle);
    }

    private void SetPosition()
    {
        transform.position = _player.position + _player.forward * Offset.z + _player.up * Offset.y;
    }
}
