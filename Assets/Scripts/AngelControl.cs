using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelControl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        // rb.velocity = transform.forward * speed;

        rb.AddForce(new Vector3(0, 1, 0), ForceMode.VelocityChange);



    }
}