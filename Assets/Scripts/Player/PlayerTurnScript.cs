using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnScript : MonoBehaviour {

    [Header("Properties")]
    [SerializeField]
    private float angleVelocity;

    [SerializeField]
    private PlayerScript player;

    // Use this for initialization   
    void Start () {
        player = GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        float giro = 0.0f;
        float delta = Time.deltaTime;

        //float actualGiro = 0.0f;       
        if (Input.GetAxisRaw("HorizontalP" + player.getPlayerNumber()) > 0)
        {//derecha
            giro = angleVelocity;
        }
        else if (Input.GetAxisRaw("HorizontalP" + player.getPlayerNumber()) < 0)
        {//izquierda
            giro = -angleVelocity;
        }

        transform.Rotate(new Vector3(0, giro * Time.deltaTime, 0));
        
    }           
}
