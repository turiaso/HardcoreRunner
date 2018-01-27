using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private string _tagPlayer;

    [Header("EnemyProperties")]
    public float _speed;

    private Transform _player;

    void Start()
    {
        GetPlayer();
    }

    private void GetPlayer()
    {
        var go = GameObject.FindGameObjectWithTag(_tagPlayer);
        if (go != null)
        {
            _player = go.transform;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_player != null)
            FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.Translate(( _player.position - transform.position ).normalized * _speed);
    }
}
