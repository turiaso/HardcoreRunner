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

    public float _delayToStart;

    private Transform _player;

    private bool _following;

    void Start()
    {
        GetPlayer();
        LevelManager.Instance.OnLevelStart -= OnLevelStart;
        LevelManager.Instance.OnLevelStart += OnLevelStart;

        LevelManager.Instance.OnLevelFinish -= OnLevelFinish;
        LevelManager.Instance.OnLevelFinish += OnLevelFinish;
    }

    private void OnLevelFinish(bool sucess)
    {
        _following = false;
    }

    private void OnLevelStart()
    {
        StartCoroutine(DelayToStartCo());
    }

    private IEnumerator DelayToStartCo()
    {
        yield return new WaitForSeconds(_delayToStart);
        _following = LevelManager.Instance.IsLevelStart();
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
        if (!_following)
            return;

        if (_player != null)
            FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.Translate(( _player.position - transform.position ).normalized * _speed);
    }
}
