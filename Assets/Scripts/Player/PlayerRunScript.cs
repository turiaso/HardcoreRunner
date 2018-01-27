using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunScript : MonoBehaviour
{

    [Header("Properties")]
    [SerializeField]
    private float velocityMax;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float desacceleration;
    [SerializeField]
    private float frenado;

    private float velocity = 0.0f;

    private PlayerScript player;

    // Use this for initialization   
    void Start()
    {
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;

        float actualAcc = Input.GetAxis("VerticalP" + player.getPlayerNumber());

        if (actualAcc == 0)
        {
            //arriba o nada
            actualAcc = desacceleration;
        }
        velocity = velocity + actualAcc * delta;

        if (velocity > velocityMax)
        {
            velocity = velocityMax;
        }
        else if (velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        transform.Translate(Vector3.forward * velocity);

    }
}
