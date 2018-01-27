using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/RunSkill")]
public class Run : Skill
{
    public override void Execute()
    {
        Debug.Log("Run");
    }
}
