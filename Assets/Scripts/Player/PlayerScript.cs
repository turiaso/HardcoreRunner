using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [Header("Properties")]
    [SerializeField]
    private int playerNumber = 1;


    // Use this for initialization   
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    } 

    public int getPlayerNumber()
    {
        return playerNumber;
    }


}
        