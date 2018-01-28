using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPhysicsScript : MonoBehaviour
{

    [SerializeField]
    private float _collisionStrengh;

    [SerializeField]
    private float _angleExtraTop;

    [SerializeField]
    private float loopTime;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Contains("Player"))
        {
            Debug.Log("Collision");
            //collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50);
            //GetComponent<Rigidbody>().AddForce(-transform.forward * 50);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Collision");
            bool hasCargar = false;
            foreach(Skill skill in LevelManager.Instance.GetComponentInChildren<SkillController>().skillsList)            {
                if (skill is Carga &&
                    skill.getPlayerID() == collision.gameObject.GetComponentInParent<PlayerScript>().getPlayerNumber() &&
                    skill.isReady() )
                {
                    hasCargar = true;
                }
            }
            if (hasCargar)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _angleExtraTop / 90 + collision.contacts[0].normal * _collisionStrengh, ForceMode.Impulse);
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.contacts[0].normal * _collisionStrengh);
            }
            else
            {
                collision.gameObject.GetComponentInParent<PlayerRunScript>().velocity -= collision.gameObject.GetComponentInParent<PlayerScript>().reduccionVelocity;
            }
        }
    }

   
}