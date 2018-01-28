using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] pogos;
    // Use this for initialization

    [SerializeField]
    private float radio;

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject pogo in pogos)
        {
           //TODO: Hacer Pogo
        }
    }
}
