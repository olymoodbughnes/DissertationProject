using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    private string finalScore;
    private double finalCoinScore;
    private int Score;
    private int maxCoinScoreTop;
    private int maxCoinScoreMid;
    private int maxCoinScoreBot;
    private string pathChosen;
    double  percScore;

    private void Update()
    {
        print(maxCoinScoreMid);
    }
    public void Tally()
    {
        


        if (pathChosen == "Up")
        {
           setFinalCoinScoreTop(finalCoinScore);
            Score += 500;
            if (percScore >= 40 && percScore < 60)
            {
                print("Not bad");
                Score += 200;
                
            }
            if (percScore > 60 && percScore < 80)
            {
                print("Nice");
                Score += 500;
            }
            if (percScore == 100)
            {
                print("PERFECT!!");
                Score += 900;

            }
            else
            {
                print("Keep going");
                Score += 2;
            }
            
        }
       if(pathChosen == "Mid")
        {
            setFinalCoinScoreMid(finalCoinScore);
            Score += 2500;
            if (percScore >= 40 && percScore < 60)
            {
                print("Not bad");
                Score += 300;

            }
            if (percScore > 60 && percScore < 80)
            {
                print("Nice");
                Score += 600;
            }
            if (percScore == 100)
            {
                print("PERFECT!!");
                Score += 1500;

            }
            else
            {
                print("Keep going");
                Score += 20;
            }
        }
        if (pathChosen == "Down")
        {
           setFinalCoinScoreBot(finalCoinScore);
            Score += 2000;
            if (percScore >= 40 && percScore < 60)
            {
                print("Not bad");
                Score += 200;

            }
            if (percScore > 60 && percScore < 80)
            {
                print("Nice");
                Score += 500;
            }
            if (percScore == 100)
            {
                print("PERFECT!!");
                Score += 1000;

            }
            else
            {
                print("Keep going");
                Score += 2;
            }
        }

        print("SCORE: " +  percScore + "% + " + Score );
        writeFinalScore();
    }
    public void setScore(int playerScore) {

        Score = playerScore;

    }

    public void setCoinScore(int playerScore)
    {

        finalCoinScore = playerScore;

    }

    public int getScore()
    {
        return Score;

    }

    //Top path score functions==========================
    public void setMaxScoreTop(int totalCoins)
    {

        maxCoinScoreTop += totalCoins;

    }


    public int getMaxScoreTop()
    {
        return maxCoinScoreTop;

    }

    //Total collected coins
    public void setFinalCoinScoreTop(double levelScore)
    {

        var value = ((double)levelScore / maxCoinScoreTop) * 100;
        percScore = System.Convert.ToInt32(System.Math.Round(value, 0));

    }
    //--------------------------------------------------


    //Mid path score functions==========================
    public void setMaxScoreMid(int totalCoins)
    {

        maxCoinScoreMid += totalCoins;

    }


    public int getMaxScoreMid()
    {
        return maxCoinScoreMid;

    }

    //Total collected coins
    public void setFinalCoinScoreMid(double levelScore)
    {

        var value = ((double)levelScore / maxCoinScoreMid) * 100;
         percScore = System.Convert.ToInt32(System.Math.Round(value, 0));
      

    }
    //--------------------------------------------------

    //Bot path score functions==========================
    public void setMaxScoreBot(int totalCoins)
    {

        maxCoinScoreBot += totalCoins;

    }


    public int getMaxScoreBot()
    {
        return maxCoinScoreBot;

    }

    //Total collected coins
    public void setFinalCoinScoreBot(double levelScore)
    {

        var value = ((double)levelScore / maxCoinScoreBot) * 100;
        percScore = System.Convert.ToInt32(System.Math.Round(value, 0));

    }
    //--------------------------------------------------

    public void path(string choice) {

        pathChosen = choice;
    
    }
    
    
    public string getFinalScore()
    {
        return finalScore;

    }

    public void writeFinalScore()
    {
        int lastLevelScore = System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/ScoreTracker.txt"));
        finalScore = Score.ToString();

        int UltimateScore = lastLevelScore + System.Int32.Parse(finalScore);
        string UltimateScoreToString = UltimateScore.ToString();
        File.WriteAllText(Application.persistentDataPath + "/ScoreTracker.txt", UltimateScoreToString);

    }

    public void readFinalScore()
    {
        finalScore = File.ReadAllText(Application.persistentDataPath + "/ScoreTracker.txt");
        

    }

     public void clearFinalScore()
    {
        File.WriteAllText(Application.persistentDataPath + "/ScoreTracker.txt", string.Empty);



    }

}
