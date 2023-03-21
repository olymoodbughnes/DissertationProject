using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LTSawSpawner : MonoBehaviour
{
    //PUBLIC=========================================================================
    //Saws 
    public GameObject spinSaw;
    //-------------------------------------------------------------------------------


    //PRIVATE========================================================================
    //Possible positions at which saw can be spawned in Vector3 format
    private Vector3[] SawPos;

    //Settings object
    private Settings mode;

    //Current difficulty setting
    private string diff;

    //Saws To Spawn
    private int STS;

    //Enumerated position at which saw will be spawned
    private int randDisplacement;

    //Random number which defines which position a spike will spawn in
    private List<int> randNum;
    //-------------------------------------------------------------------------------

    private void Start()
    {
        //Saw Positions
        SawPos = new Vector3[] {
                                    new Vector3(5.5f, -0.5f),
                                    new Vector3(6, 3.5f),
                                    new Vector3(7.5f, 4.5f),
                                    new Vector3(7.5f, -1.5f)
                                };


        //List containing the length of spike positions as a list
        randNum = new List<int> { };

        //Fill list depending on size of SawPos
        for (int i = 0; i < SawPos.Length; i++) { randNum.Add(i); }

        //Get difficulty setting from Settings game object
        mode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        diff = mode.getDifficulty();



        //Set the Saws To Spawn depending on the difficulty
        switch (diff)
        {
            case "easy":
                STS = 1;
                break;

            case "medium":
                STS = 2;
                break;

            case "hard":
                STS = 3;
                break;
        }

        for (int i = 0; i < STS; i++)
        {
            //If difficulty is 'hard', have a chance of spawning a third spike
            if (STS == 3 && i < 1)
            {

                int rand = Random.Range(0, 100);

                //40% chance of spawning the third spike
                if (rand > 60)
                {
                    //Choose randomly out of the predefined spawning locations
                    var index = Random.Range(0, randNum.Count);
                    randDisplacement = randNum[index];

                    spawnSaw();

                    //Remove the position at which the spike has just been spawned
                    randNum.RemoveAt(index);
                    //Increase the total number of saw by one
                }
            }
            else
            {
                //Choose randomly out of the predefined spawning locations
                var index = Random.Range(0, randNum.Count);
                randDisplacement = randNum[index];

                spawnSaw();

                //Remove the position at which the spike has just been spawned
                randNum.RemoveAt(index);
                //Increase the total number of saw by one
            }
        }
    }

    public void spawnSaw()
    {


        if (randDisplacement == 3)
        {

            Instantiate(spinSaw, transform.position + SawPos[randDisplacement], Quaternion.Euler(0, 0, 270));

        }
   

        else
        {


            //Spawn a spike at position [random] of the array holding all positions
            Instantiate(spinSaw, transform.position + SawPos[randDisplacement], Quaternion.identity);
        }



    }
}
