using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;

    private string Score;

    private string message;

    private void Start()
    {
        Score = File.ReadAllText(Application.persistentDataPath + "/ScoreTracker.txt");

        if (System.Int32.Parse(Score) <= 5000)
        {
            message = "GOOD JOB";
        }
        else if (System.Int32.Parse(Score) > 5000)
        {
            message = "NICE!!";
        }
        else if (System.Int32.Parse(Score) >= 15000)
        {
            message = "VERY NICE YESSSS!!!!";
        }
        else if (System.Int32.Parse(Score) >= 30000)
        {
            message = "UNBELIEVABLE!!!!";
        }

        ScoreText.text ="YOUR FINAL SCORE IS: " + Score + " " + "\n" + message;
    }
    public void LoadMainMenu() {
             
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
          
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);

        }

    public void ClearLastRun() {
       
        

        File.WriteAllText(Application.persistentDataPath + "/ScoreTracker.txt", 0.ToString());

    }
}
