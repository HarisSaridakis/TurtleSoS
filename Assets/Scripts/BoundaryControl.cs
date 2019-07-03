using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoundaryControl : MonoBehaviour {
    public Text ScoreText;
    private Rigidbody rb;
    public int AliveTurtles;
    public int lifes;
    public int HighScore;

    public bool timerCheck = false;
    public float timer = 0;
    private Animation Plats;
    


    void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag == "Turtle") // triggers every time a turtle makes it to the sea 
        {
            Destroy(other.gameObject);
        

            SetScore();
        }
        if (other.gameObject.tag == "Garbage") // if a garbage draged to the seas moves down
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.down * 2;



        }

    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "Garbage") // when a garbage exit stops moving
        {
            rb.velocity = Vector3.zero;
        }

    }

    void SetScore() {
      
        AliveTurtles += 1; // for every alive turtle AliveTurtles increases by one
        ScoreText.text =""+ AliveTurtles.ToString();
       
      
   
    }

  


   



}

