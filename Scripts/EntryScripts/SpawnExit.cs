using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnExit : MonoBehaviour
{

    public GameObject exit;
    public Settings difficulty;
    private string setMode;
    private Vector3 exitLocation;
    public EntryReference entry;
    public void spawnExit()
    {
        difficulty = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        entry = GameObject.FindGameObjectWithTag("Start").GetComponent<EntryReference>();

        setMode = difficulty.getDifficulty();

        switch (File.ReadAllText(Application.persistentDataPath + "/Difficulty.txt"))
        {
            case "easy":
                exitLocation = setEasy(entry.getLoc());
                break;

            case "medium":
                exitLocation = setMedium(entry.getLoc());
                break;

            case "hard":
                exitLocation = setHard(entry.getLoc());
                break;
        }

        //choose where to spawn exit depending on the difficulty set, default value is easy
        
        Instantiate(exit, exitLocation, Quaternion.identity);
    }

    public Vector3 setEasy(Vector3 exit) {

        exit += new Vector3(30, 0, 0);
        
        
        return exit;
    
    
    }  
    public Vector3 setMedium(Vector3 exit) {

        exit += new Vector3(70, 0, 0);
        
        
        return exit;
    
    
    } 
    public Vector3 setHard(Vector3 exit) {

        exit += new Vector3(120, 0, 0);
        
        
        return exit;
    
    
    }
}
