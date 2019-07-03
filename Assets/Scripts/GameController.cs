using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Vector3 AngelPosition;    //Position of 
    private bool timerCheck = false;
    private float timer = 0;
    private Collider col;
    private bool Halt;
    private int cnt;
    public GameObject[] hazards;
    private GameObject[] AlreadyPlaced;
    public Vector3 SpawnValues;
    public float ymax;
    public int GarbageSpawn;
    public int TurtleSpawn;
    public GameObject Turtle;
    
    public AudioSource Theme;
    private Vector3 target;
    private float spawnWait;
    private int counter=0;
    private List<Vector3> gridPositions = new List<Vector3>();
    private Vector3[] Positions = new Vector3[48];
    private int GarbageCount;
    private List<Vector3> SpawnPositions = new List<Vector3>();
    private List<Vector3> OccupiedPos = new List<Vector3>();
    private Vector3 offset;

    void Start()
    {
    

         GarbageCount = 0;
     
        spawnWait = 0.5F;

	
         InitialiseList();
        ChooseALevel();
        Debug.Log("TurtleSpawn" + TurtleSpawn);



       SpawnGarbage();

        InitializeSpawnTurtles();
        StartCoroutine(SpawnTurtles());
    }





   void InitializeSpawnTurtles()    //Initialize the location of the garbage on screen 
    {



        for (int t = -8; t < 6; t++)
        {

             Vector3 spawnPosition = new Vector3(t, -5.5F, SpawnValues.z);
         
            SpawnPositions.Add(spawnPosition);
        }
    } 




    IEnumerator SpawnTurtles()  //
    {
    
        Vector3 PreviousSpawn= new Vector3(20F, 20F, 20F);  // Initiallize the spawn position
        while (counter <TurtleSpawn)
        {
       



             
            for (int i = 0; i <3; i++)
                {


             Vector3 spawnPosition = SpawnPositions[Random.Range(0, SpawnPositions.Count)];

        
             while (spawnPosition == PreviousSpawn) // To avoid overlap of two turtles in same position 
                                                    // checks if the previous position is same with the current
                {
                     spawnPosition = SpawnPositions[Random.Range(0, SpawnPositions.Count)]; //Picks a new one
                }

                Instantiate(Turtle, spawnPosition, Quaternion.identity);
                PreviousSpawn = spawnPosition;
                yield return new WaitForSecondsRealtime(0.8F); // waits for 0.8 seconds be fore spawn a new one
                }
                counter++;
           
           yield return new WaitForSecondsRealtime(0.8F); // waits for 0.8 seconds before for loop starts again
        }
    }






    public void SpawnGarbage()
    {

       




            for (int i = 0; i < GarbageSpawn; i++)
        {
            GameObject Garbage = hazards[Random.Range(0, hazards.Length)]; //Randomly chooses a garbage from list
         
            for (int cnt = 0; cnt < gridPositions.Count; cnt++) // loops throug all poisitions
            {
           
             Vector3 SpawnGarbagePosition = gridPositions[Random.Range(0, gridPositions.Count)];// Randomly chooses a position from list


                if (OccupiedPos.Contains(SpawnGarbagePosition)== false) //Check if is not taken
              
                {

                   
                    Instantiate(Garbage, SpawnGarbagePosition, Quaternion.identity);

                      OccupiedPos.Add(SpawnGarbagePosition); //add position to ocupied list
                   
                    GarbageCount++;
                    break;
                }
            }


        }
            

    }


  




    void InitialiseList() //initialise positions for garbage 
    {
        
        gridPositions.Clear();

   
        for (float x = -SpawnValues.x; x < 6.5; x++)
        {
           
            for (float y = SpawnValues.y; y > ymax; y--)
             {
           
                gridPositions.Add(new Vector3(x, y, -2F));
         
             }
        }
    }



    void ChooseALevel() // determines the level and assigns number of turtles to spawn
    {
    
        Debug.Log("level: "+ LevelLoad.level);
        switch (LevelLoad.level)
        {
            case 1:                //Level 1
                TurtleSpawn = 3; //3*3
                GarbageSpawn = 10;
           
                break;
            case 2:             //Level 2

                TurtleSpawn = 6; //3*9
                GarbageSpawn = 17;
              
                break;
            case 3:          //Level 3

                TurtleSpawn = 10; //3*10
                GarbageSpawn = 27;
         
                break;
            default:
                TurtleSpawn = 3; //default for testing
                GarbageSpawn = 10;
                Turtle.GetComponent<Move>().speed = 0.8F;
                Debug.Log("Deafault Error");
                break; 
        }



    }




 

  

}