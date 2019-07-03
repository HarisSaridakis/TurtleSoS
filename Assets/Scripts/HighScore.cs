using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public static int CurrentScore;
    private int TopScore;
    public  Text HighScoreText;
    private string gameDataFileName = "HighScores.json";
    private string gameDataProjectFilePath = "/StreamingAssets/HighScores.json";
    public Box Gar;
    High LoadData;


     void Start()
    {
       
        LoadGameData();
        HighScoreText.text = "HighScore " + TopScore.ToString();
    }

    public void SetHighScore()
    {
       CurrentScore= Gar.Garbage;
        if (CurrentScore > TopScore)
        {


            LoadData.score = CurrentScore;
            string SaveJson = JsonUtility.ToJson(LoadData);
            Debug.Log("newHighScore" + SaveJson);
            string filePath = Application.dataPath + gameDataProjectFilePath;
            File.WriteAllText(filePath, SaveJson);
        }



    }


    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {

            string dataAsJson = File.ReadAllText(filePath);

            LoadData = JsonUtility.FromJson<High>(dataAsJson);
            // Debug.Log("Loaded"+LoadData.HighScore);
            TopScore = LoadData.score;


        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}

[System.Serializable]
public class High
{

    public int score;
}
