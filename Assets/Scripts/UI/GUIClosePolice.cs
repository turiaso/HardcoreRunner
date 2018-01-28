using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIClosePolice : MonoBehaviour
{

    public Transform _enemy;
    public Transform _player;

    public float _enemyCloseToPlayerDistance;

    public GameObject _policeFace;

    void Start()
    {
        if (_policeFace.activeSelf) _policeFace.SetActive(false);
    }

    void Update()
    {
        if (( _enemy.position - _player.position ).sqrMagnitude < _enemyCloseToPlayerDistance * _enemyCloseToPlayerDistance)
        {
            if (!_policeFace.activeSelf) _policeFace.SetActive(true);
            GetComponent<AudioPlay>().Play();
        }
        else
        {
            if (_policeFace.activeSelf) _policeFace.SetActive(false);
        }
    }
}
