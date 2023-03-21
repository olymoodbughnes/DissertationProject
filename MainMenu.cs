using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        TextWriter tw = new StreamWriter(Application.persistentDataPath + "/Lives.txt");
        tw.Write("3");
        tw.Close();
        TextWriter tw2 = new StreamWriter(Application.persistentDataPath + "/Difficulty.txt");
        tw2.Write("easy");
        tw2.Close();
        TextWriter tw3 = new StreamWriter(Application.persistentDataPath + "/ScoreTracker.txt");
        tw3.Write("0");
        tw3.Close();

    }
    public void PlayLV() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }
    public void QuitGame() {

        Application.Quit();
    
    }
}
