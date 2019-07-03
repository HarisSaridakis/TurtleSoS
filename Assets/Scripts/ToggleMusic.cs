using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ToggleMusic : MonoBehaviour {

    public Sprite SwitcOn;
    public Sprite SwitchOff;
    public Button SoundSwitch;
    public AudioSource GameSound;
  //  private bool State=false;

    void Start()
    {
        
        SoundSwitch.onClick.AddListener(ButtonClicked);

        Music();
    }

   
    void ButtonClicked() {
         LevelLoad.SoundCheck = !LevelLoad.SoundCheck;

        Music();



    }


    void Music() {

        if (LevelLoad.SoundCheck)
        {
            SoundSwitch.image.sprite = SwitchOff;

            GameSound.Stop();
        }
        else
        {

            SoundSwitch.image.sprite = SwitcOn;
            GameSound.Play();
        }
    }
}
