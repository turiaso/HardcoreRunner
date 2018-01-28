using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnScript : MonoBehaviour
{

    [Header("Properties")]
    [SerializeField]
    private float angleVelocity;


    private PlayerScript player;


    // Use this for initialization   
    void Start()
    {
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Instance.IsLevelStart())
            return;

        float giro = Input.GetAxis("HorizontalP" + player.getPlayerNumber()) * angleVelocity;
        if (giro == 0)
        {
            giro = Input.GetAxis("HorizontalP" + player.getPlayerNumber() + "PC") * angleVelocity;
        }
        /*
        float giro = 0.0f;
        float delta = Time.deltaTime;
        if (Input.GetAxis("HorizontalP" + player.getPlayerNumber()) > 0)
        {//derecha
            giro = angleVelocity;
        }
        else if (Input.GetAxis("HorizontalP" + player.getPlayerNumber()) < 0)
        {//izquierda
            giro = -angleVelocity;
        }

    */
        transform.Rotate(new Vector3(0, giro * Time.deltaTime, 0));

    }
}
