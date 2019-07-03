using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public Button Lvl2;
    public Button Lvl3;
    public bool Progress;

    void Start() {
        Progress = true;
        Switch();
       
            }

    void Switch(){

        
        Debug.Log("Nextlevel: " + LevelLoad.Nextlevel);

        if (Progress)
        {
            switch (LevelLoad.Nextlevel)
            {
                case 2:
                    Lvl2.interactable = true; ;
                    Lvl3.interactable = false;
                    break;

                case 3:
                    Lvl3.interactable = true;
                    break;
                default:
                    Lvl2.interactable = false;
                    Lvl3.interactable = false;
                    Progress = false;
                    Debug.Log(" Switch Error");
                    break;
            }

        }
    }
}
