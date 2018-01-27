using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FanBehaviourScript : MonoBehaviour
{

    public virtual void Init() { }
    public abstract void Fun(float elapseTime);
}
