using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
    private Vector3 AngelPosition;
    private Vector3 movement;
    private Vector3 target;
    public bool timerCheck = false;
    public float timer = 0;
    public float speed;
    private Rigidbody rb;
    public GameObject AngelTurtle;
    public Animator anim;
    public static int step;
    private float targetManeuver;
    private string WhatIs;
    private GameObject allos;
    public Sprite Group;
    public GameObject Hsystem;

    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
       rb.velocity = transform.up * speed; //Turtle movement
      
    }


    void Update()
    {




        if (timerCheck) //starts a counter if turtle is block by garbage
        {
            timer += Time.deltaTime;
            // Debug.Log("timer = " + Mathf.Floor(timer % 60));


            // transform.Rotate(new Vector3(1, 0, Mathf.Floor(timer % 60)), Space.Self);
            // transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        }
        if (Mathf.Floor(timer % 60) == 6) 
        {
            AngelPosition = new Vector3(transform.position.x, transform.position.y, -4F); 

            Destroy(gameObject); // destory turtle object

            SpawnAngel();

        }



    }



    /*public void SplashWater()
    {



        anim.SetTrigger("SandEdge");

    }*/

    void OnTriggerEnter(Collider other) // check for triggerd collision between a turtle with another turtle
    {

        if (other.gameObject.tag == "Turtle")
        {
            if (gameObject.transform.position.y > -5F)
            {
               
                allos = other.gameObject;
                timerCheck = true; // timer set to true
                rb.velocity = Vector3.zero; // turtle stops
             


                anim.SetBool("Obstacle", true); //animation of movement stops
             
            }
        }

          /*  if (other.gameObject.tag == "Boundary")
            {

                Debug.Log("Enter Boundary");
                SplashWater();

            }*/

         



        }

    

    void OnTriggerExit(Collider other)
    {
      

        if (other.gameObject.tag == "Turtle")  // Collision ends
         
        {

            timerCheck = false;
            timer = 0;
            anim.SetBool("Obstacle", false);
            Debug.Log("Exit! ");

           
         
               Start();
          

        }


      
    }



     void FauxExit()  //artifficial  OnTriggerExit, if there are more than two turtles collide if the mid turtle died the last 
                      //will never exit collision  
    {
        anim.SetBool("Obstacle", false);
        try
        {

            allos.gameObject.GetComponent<Move>().timerCheck = false;
            allos.gameObject.GetComponent<Move>().timer = 0;
            allos.gameObject.GetComponent<Move>().anim.SetBool("Obstacle", false);
            allos.gameObject.GetComponent<Rigidbody>().velocity = allos.gameObject.transform.up * 0.75F;

        }
        catch (MissingReferenceException e)
        {

            Debug.Log("Oops" + e);
        }
        catch (System.NullReferenceException ex)
        {
            Debug.Log("Oops" + ex);

        }

    }
    void SpawnAngel() // intantiate an angel turtle
    {
        Debug.Log("WhatIs " + WhatIs);

     
        FauxExit();

        

        Instantiate(AngelTurtle, AngelPosition, Quaternion.identity);
      
        DeadTurtlesCounter.DeadTurtle += 1;
        HealthSystem.IsDead = true; // isDead sets true to remove a heart
    }


   

  
}
