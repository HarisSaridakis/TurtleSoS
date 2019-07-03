using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeadTurtlesCounter : MonoBehaviour {

    public static int DeadTurtle;

 
    public int lifes;  // The player's score.
    public GameObject GameOver;
    public HighScore Hs;
    public Box Bin;
    public GameController GC;
    public BoundaryControl Boundary;
    public Text text;                      // Reference to the Text component.
    public GameObject NextLevel;
    public int dead;
    private int GarbageSpawn;
    private int TurtleSpawn;
    private int AliveTurtles;
    private int GarbageInTheBin;
    void Awake()
    {

        

        // Reset the score.
        DeadTurtle = 0;
      
    }


    void Update()
    {

         GarbageSpawn = GC.GarbageSpawn;   // gets the number of garbage will spawn
         TurtleSpawn = GC.TurtleSpawn *3;   // gets the number of turtles will spawn
        AliveTurtles = Boundary.AliveTurtles;  // gets the number of turtles that make it to the sea
        GarbageInTheBin = Bin.GarbageInTheBin; // gets the number of garbage in the trash bin

        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "" + DeadTurtle;
   
        

     

        
            switch (DeadTurtle) //checks if the level is clear 
                                //calls function with the  number of turtles that make it to the sea 
                                //as an argument 
        {
            case 1:
                    NextLevelScreen(TurtleSpawn -1);  //if one turtle is dead
                    //Debug.Log("1 Dead Turtle ");
                    break;

                case 2:
                    NextLevelScreen(TurtleSpawn - 2); //if two turtles are dead
                  //  Debug.Log("2 Dead Turtles");
                    break;
                case 3:
                  // Debug.Log("GameOver");
                    GameOver.SetActive(true); //gameover 
                  Clear();
                break;
               default:
                NextLevelScreen(TurtleSpawn);
               // Debug.Log("Default state ");

                break;
            }

        


    }


    void NextLevelScreen(int Alive)
    {


        if (GarbageSpawn  == GarbageInTheBin) // check if all spawn garbages are in trash bin
         if(AliveTurtles == Alive)  // check if alive turtles is equal with the amount of turtles 
                                    //should be alive in order to finish the level
            {

            NextLevel.SetActive(true);
            Clear();
        }



    }

    void Clear() // destroys all the turtles and garbages
    {


        GameObject[] turtles;
        GameObject[] Garbages;

        Garbages = GameObject.FindGameObjectsWithTag("Garbage");
        turtles = GameObject.FindGameObjectsWithTag("Turtle");
      
            Hs.SetHighScore();
        foreach (GameObject turtle in turtles)
        {
            Destroy(turtle);
        }

        foreach (GameObject Garbage in Garbages)
        {
            Destroy(Garbage);
        }


    }
}
