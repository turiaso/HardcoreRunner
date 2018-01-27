using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {
    [SerializeField]
    private Skill[] skillsList;

    [SerializeField]
    private GameObject marcador;

    // Use this for initialization
    void Start () {
        skillsList = GetComponents<Skill>();
    }
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(skillsList.Length);
	}
}
