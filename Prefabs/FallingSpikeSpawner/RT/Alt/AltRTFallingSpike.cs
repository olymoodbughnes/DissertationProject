using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AltRTFallingSpike : MonoBehaviour
{
    //PUBLIC=========================================================================
    //Spikes 
    public GameObject spikes;
    //-------------------------------------------------------------------------------


    //PRIVATE========================================================================
    //Possible positions at which spikes can be spawned in Vector3 format
    private Vector3[] SpikePos;

    //Settings object
    private Settings mode;

    //Current difficulty setting
    private string diff;

    //Spikes To Spawn
    private int SpTS;

    //Enumerated position at which spikes will be spawned
    private int randDisplacement;

    //Random number which defines which position a spike will spawn in
    private List<int> randNum;
    //-------------------------------------------------------------------------------

    private void Start()
    {
        //Spike Positions
        SpikePos = new Vector3[] {  new Vector3(2, -0.49f),
                                    new Vector3(8, 3.49f),
                                    new Vector3(9.5f, -1.49f)
                                };


        //List containing the length of spike positions as a list
        randNum = new List<int> { };

        //Fill list depending on size of SpikePos
        for (int i = 0; i < SpikePos.Length; i++) { randNum.Add(i); }

        //Get difficulty setting from Settings game object
        mode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        diff = mode.getDifficulty();



        //Set the Spikes To Spawn depending on the difficulty
        switch (diff)
        {
            case "easy":
                SpTS = 1;
                break;

            case "medium":
                SpTS = 2;
                break;

            case "hard":
                SpTS = 3;
                break;
        }

        for (int i = 0; i < SpTS; i++)
        {
            //If difficulty is 'hard', have a chance of spawning a third spike
            if (SpTS == 3 && i < 1)
            {

                int rand = Random.Range(0, 100);

                //40% chance of spawning the third spike
                if (rand > 60)
                {
                    //Choose randomly out of the predefined spawning locations
                    var index = Random.Range(0, randNum.Count);
                    randDisplacement = randNum[index];

                    spawnSpike();

                    //Remove the position at which the spike has just been spawned
                    randNum.RemoveAt(index);
                    //Increase the total number of spikes by one
                }
            }
            else
            {
                //Choose randomly out of the predefined spawning locations
                var index = Random.Range(0, randNum.Count);
                randDisplacement = randNum[index];

                spawnSpike();

                //Remove the position at which the spike has just been spawned
                randNum.RemoveAt(index);
                //Increase the total number of spikes by one
            }
        }
    }

    public void spawnSpike()
    {
        //Spawn a spike at position [random] of the array holding all positions
        Instantiate(spikes, transform.position + SpikePos[randDisplacement], Quaternion.identity);
    }
}