using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Properties")]
    [SerializeField]
    private int playerNumber;


    // Use this for initialization   
    void Start()
    {
    }



    public int getPlayerNumber()
    {
        return playerNumber;
    }


}
