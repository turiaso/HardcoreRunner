using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour {
   
    private FanBehaviourScript fanBehaviourScript;

    // Use this for initialization
    void Start () {
        fanBehaviourScript = GetComponent<FanBehaviourScript>();

    }
	
	// Update is called once per frame
	void Update () {
        fanBehaviourScript.Fun(Time.deltaTime);
    }
}
