using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RBCoinSpawns : MonoBehaviour
{
    [SerializeField]
    GameObject room;
    //PUBLIC=========================================================================
    //Coins 
    public GameObject coins;
    //-------------------------------------------------------------------------------


    //PRIVATE========================================================================
    //Possible positions at which coins can be spawned in Vector3 format
    private Vector3[] CoinPos;

    //Keep track of the maximum achievable score for fairness purposes
    private ScoreKeeper maxScoreTracker;

    //Settings object
    private Settings mode;

    //Current difficulty setting
    private string diff;

    //Coins To Spawn
    private int CTS;

    //Total number of coins spawned in this instance
    private int totalCoins = 0;

    //Enumerated position at which coins will be spawned
    private int randDisplacement;

    //Random number which defines which position a coin will spawn in
    private List<int> randNum;
    //-------------------------------------------------------------------------------

    private void Start()
    {
        //Coin Positions
        CoinPos = new Vector3[] {   new Vector3(5.5f, -2.5f),
                                    new Vector3(8.5f, 0.5f),
                                    new Vector3(1.5f, 2.5f),
                                    new Vector3(2.5f, -1.5F),
                                    new Vector3(7.5f, 2.5f),

                                };


        //List containing the length of coin positions as a list
        randNum = new List<int> { };

        //Fill list depending on size of CoinPos
        for (int i = 0; i < CoinPos.Length; i++) { randNum.Add(i); }

        //Get difficulty setting from Settings game object
        mode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        diff = mode.getDifficulty();

        maxScoreTracker = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreKeeper>();

        //Set the Coins To Spawn depending on the difficulty
        switch (diff)
        {
            case "easy":
                CTS = 1;
                break;

            case "medium":
                CTS = 2;
                break;

            case "hard":
                CTS = 3;
                break;
        }

        for (int i = 0; i < CTS; i++)
        {
            //If difficulty is 'hard', have a chance of spawning a third coin
            if (CTS == 3 && i < 1)
            {

                int rand = Random.Range(0, 100);

                //40% chance of spawning the third coin
                if (rand > 60)
                {
                    //Choose randomly out of the predefined spawning locations
                    var index = Random.Range(0, randNum.Count);
                    randDisplacement = randNum[index];

                    spawnCoin();

                    //Remove the position at which the coin has just been spawned
                    randNum.RemoveAt(index);
                    //Increase the total number of coins by one
                    totalCoins++;
                }
            }
            else
            {
                //Choose randomly out of the predefined spawning locations
                var index = Random.Range(0, randNum.Count);
                randDisplacement = randNum[index];

                spawnCoin();

                //Remove the position at which the coin has just been spawned
                randNum.RemoveAt(index);
                //Increase the total number of coins by one
                totalCoins++;
            }
        }
        //Update the tracker of max coins
        if (room.tag == "TopRooms")
        {
            maxScoreTracker.setMaxScoreTop(totalCoins);
        }
        else if (room.tag == "MiddleRooms")
        {
            maxScoreTracker.setMaxScoreMid(totalCoins);
        }
        else if (room.tag == "BottomRooms")
        {
            maxScoreTracker.setMaxScoreBot(totalCoins);
        }
    }

    public void spawnCoin()
    {
        //Spawn a coin at position [random] of the array holding all positions
        Instantiate(coins, transform.position + CoinPos[randDisplacement], Quaternion.identity);
    }
}