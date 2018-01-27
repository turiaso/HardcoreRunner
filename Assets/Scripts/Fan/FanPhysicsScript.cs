using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPhysicsScript : MonoBehaviour {

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision");
    //}

   private void OnTriggerEnter(Collider collider)
   {
       if (collider.tag.Contains("Player"))
       {
            Debug.Log("Collision");
            collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50);
            GetComponent<Rigidbody>().AddForce(-transform.forward * 50);
        }
   }
}