using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField]
    private Text modeText;
    private bool crazy;
    private List<string> modes  = new List<string> { "easy", "medium", "hard"};

    //difficulty setting: easy/medium/hard  INFO: easy should always be default
    public string mode;

    private void Start()
    {
        mode = File.ReadAllText(Application.persistentDataPath + "/Difficulty.txt");


        if (mode == "crazy") {

            crazy = true;

        }
        else
        {
            crazy = false;
        }
        if (crazy == true)
        {
            int rand = Random.Range(0, 3);
            mode = modes[rand];
            TextWriter tw = new StreamWriter(Application.persistentDataPath + "/Difficulty.txt");
            tw.Write(string.Empty);
            tw.Write(mode);
            tw.Close();
            modeText.text = "Mode: " + mode;
        }

        if (mode != "crazy")
        {
            modeText.text = "Mode: " + mode;
        }
       
    }


    public void setDifficulty(string diffiiculty) {
        mode = diffiiculty;
    
    }



    public string getDifficulty()
    {
        return mode;

    }


    public void readDifficulty()
    {
       mode = File.ReadAllText(Application.persistentDataPath + "/Difficulty.txt");


    }
}
