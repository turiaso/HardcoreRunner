using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Camera Properties")]
    [SerializeField]
    private string _tagPlayer;

    [SerializeField]
    private float _rotationAngle;

    private Transform _player;


    public Vector3 juan { get; set; }

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
        SetCamera();
    }

    private void SetCamera()
    {
        transform.rotation = Quaternion.Euler(_rotationAngle, _player.rotation.eulerAngles.y, 0);
    }

    private void SetPosition()
    {
        transform.position = _player.position + _player.forward * Offset.z + _player.up * Offset.y;
    }
}
