using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour
{
    [SerializeField]
    private string _player01Tag;

    [SerializeField]
    private string _player02Tag;

    [SerializeField]
    private string _enemy01Tag;

    [SerializeField]
    private string _enemy02Tag;

    [SerializeField]
    private string _goalTag;


    private Transform _player01;
    private Transform _player02;

    private EnemyController _enemy01;
    private EnemyController _enemy02;

    private Transform _goal;


    private Vector3 _player01StartPosition;
    private Vector3 _player02StartPosition;

    public RectTransform _bgBar;
    public RectTransform _player01Icon;
    public RectTransform _player02Icon;

    public RectTransform _enemy01Icon;
    public RectTransform _enemy02Icon;

    private float _maxPlayer1Distance;
    private float _maxPlayer2Distance;

    public void Start()
    {
        var go = GameObject.FindGameObjectWithTag(_player01Tag);
        if (go != null)
            _player01 = go.transform;

        go = GameObject.FindGameObjectWithTag(_player02Tag);
        if (go != null)
            _player02 = go.transform;

        go = GameObject.FindGameObjectWithTag(_enemy01Tag);
        if (go != null)
            _enemy01 = go.GetComponent<EnemyController>();

        go = GameObject.FindGameObjectWithTag(_enemy02Tag);
        if (go != null)
            _enemy02 = go.GetComponent<EnemyController>();

        go = GameObject.FindGameObjectWithTag(_goalTag);
        if (go != null)
            _goal = go.transform;


        _player01StartPosition = _player01.transform.position;
        _player02StartPosition = _player02.transform.position;

        _maxPlayer1Distance = ( _goal.position - _player01StartPosition ).magnitude;
        _maxPlayer2Distance = ( _goal.position - _player02StartPosition ).magnitude;
    }

    private void Update()
    {
        UpdatePlayerPos(_player01, _player01Icon, _maxPlayer1Distance, true);
        UpdatePlayerPos(_player02, _player02Icon, _maxPlayer2Distance, false);
    }

    private void UpdatePlayerPos(Transform player, RectTransform playerIcon, float maxDistance, bool left)
    {
        Vector3 distanceToGoal = _goal.position - _player01.position;
        float distanceToGoalMagnitude = distanceToGoal.magnitude;
        if (distanceToGoalMagnitude > maxDistance)
        {
            playerIcon.transform.position = new Vector3(_bgBar.sizeDelta.x * _bgBar.lossyScale.x * 0.5f * ( left ? -1 : 1 ),
                playerIcon.transform.position.y, playerIcon.transform.position.z);
        }
        else
        {
            float distancePercentage = distanceToGoalMagnitude / maxDistance;

        }
    }
}
