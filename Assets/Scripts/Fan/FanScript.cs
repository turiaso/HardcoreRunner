using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{

    [SerializeField]
    private FanBehaviourScript fanBehaviourScript;

    // Use this for initialization
    void Start()
    {
        if (fanBehaviourScript != null)
            fanBehaviourScript.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (fanBehaviourScript != null)
            fanBehaviourScript.Fun(Time.deltaTime);
    }


}
