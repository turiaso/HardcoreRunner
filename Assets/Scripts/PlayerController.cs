using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _playerNumber;

    [SerializeField]
    private List<Skill> _fixSkills;

    [SerializeField]
    private List<Skill> _shareSkills;

    public void Update()
    {





        if (isSkill01Pressed())
        {
            ExecuteSkill01();
        }
        if (isSkill02Pressed())
        {
            ExecuteSkill02();
        }
        if (isSkill03Pressed())
        {
            ExecuteSkill03();
        }
    }


    private bool isSkill01Pressed()
    {
        return Input.GetAxisRaw("Skill01P" + _playerNumber) > 0;
    }

    private bool isSkill02Pressed()
    {
        return Input.GetAxisRaw("Skill02P" + _playerNumber) > 0;
    }

    private bool isSkill03Pressed()
    {
        return Input.GetAxisRaw("Skill03P" + _playerNumber) > 0;
    }

    private void ExecuteSkill01()
    {

    }

    private void ExecuteSkill02()
    {

    }

    private void ExecuteSkill03()
    {

    }
}
