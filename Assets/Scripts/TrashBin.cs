using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrashBin : MonoBehaviour {

    private Rigidbody rb;
  

    void OnTriggerEnter(Collider other) // when a garbage enters collider  starts moving downwards
    {

        if (other.gameObject.tag == "Garbage")
        {
           Debug.Log("OK" );

            rb =other.gameObject.GetComponent<Rigidbody>();
             rb.velocity = Vector3.down * 2;
          
        }
    }

    void OnTriggerExit(Collider other)  //if somehow garbage did not destroy will stop moving when exit collider
    {
        
        if (other.gameObject.tag == "Garbage")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
           
        }
    }
}
