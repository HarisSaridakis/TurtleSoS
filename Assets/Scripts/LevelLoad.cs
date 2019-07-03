using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour {
    
    public static int turtle;
    public static int level;
    public static int Nextlevel;
    public static bool SoundCheck;

    public void LoadByIndex(int sceneIndex) // loads a scene
     {
		
         SceneManager.LoadScene(sceneIndex);
        
     }

	public void HowMany(int num)
	{
        turtle = num;
       


    }

  public void WhichLevel(int lvl)
    {
        level = lvl;

        Debug.Log("WhichLevel" + level);
    }

    public void NextLevel()
    {


        Debug.Log("NextLevel" + level);

        switch (level)
        {
            case 1:
                Nextlevel = 2;
                Debug.Log("NextLevel 2");
                break;
            case 2:
                Debug.Log("NextLevel 3");
                Nextlevel = 3; 
                break;
           
            default:
               
                Debug.Log("NextLevel Error");
                break;
        }



    }

}
