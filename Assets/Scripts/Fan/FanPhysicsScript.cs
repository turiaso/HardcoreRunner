using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPhysicsScript : MonoBehaviour
{

    [SerializeField]
    private float _collisionStrengh;

    [SerializeField]
    private float _angleExtraTop;

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
        Debug.Log("Collision");

        if (collision.gameObject.tag.Contains("Player"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * _angleExtraTop / 90 + collision.contacts[0].normal * _collisionStrengh, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.contacts[0].normal * _collisionStrengh);
        }
    }
}