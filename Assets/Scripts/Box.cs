using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    private Rigidbody rb;
   
    public Text ScoreText;
    public int Garbage;
    public int GarbageInTheBin;
    public GameController GC;
    public AudioSource GarbageInTrashBin; 
    public float NewGarbages;

    void Start()
    {

        Garbage = HighScore.CurrentScore;
        Debug.Log("CurrentScore"+ Garbage);
        ScoreText.text = "Score " + Garbage.ToString();
        NewGarbages *= 5;

    }
    void OnTriggerEnter(Collider other) // when a garbage enters collider destroys and the counter increases
    {

        if (other.gameObject.tag == "Garbage")
        {
          
        
        rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
       
            Debug.Log("OK");
            Destroy(other.gameObject);

            if(!LevelLoad.SoundCheck)  
            GarbageInTrashBin.Play();   //sound plays 

            GarbageCount();
        }
    }

    void GarbageCount()
    {
      GarbageInTheBin++;

        Garbage += 5;
        ScoreText.text = "Score " + Garbage.ToString(); //scre sets to screen
      
   

    }









}