using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Options : MonoBehaviour
{
  
  //Difficulty settings (access difficulty text file, clear any remaining text, write desired difficulty as a string)
  
  public void setDiffHard()
    {

        
        TextWriter tw = new StreamWriter(Application.persistentDataPath + "/Difficulty.txt");
        tw.Write(string.Empty);
        tw.Write("hard");
        tw.Close();

    }

    public void setDiffMedium()
    {

        TextWriter tw = new StreamWriter(Application.persistentDataPath + "/Difficulty.txt");
        tw.Write(string.Empty);
        tw.Write("medium");
        tw.Close();

    }

    public void setDiffEasy()
    {

        TextWriter tw = new StreamWriter(Application.persistentDataPath + "/Difficulty.txt");
        tw.Write(string.Empty);
        tw.Write("easy");
        tw.Close();

    }
    public void setDiffCrazy()
    {

        TextWriter tw = new StreamWriter(Application.persistentDataPath + "/Difficulty.txt");
        tw.Write(string.Empty);
        tw.Write("crazy");
        tw.Close();

    }

}
