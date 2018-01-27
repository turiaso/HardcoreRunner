using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField]
    private int playerID;

    public abstract void Fun(float elapseTime);
}
