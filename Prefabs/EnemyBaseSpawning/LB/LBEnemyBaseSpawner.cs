using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LBEnemyBaseSpawner : MonoBehaviour
{
    //PUBLIC=========================================================================
    //Enemies 
    public GameObject enemyBase;
    //-------------------------------------------------------------------------------


    //PRIVATE========================================================================
    //Possible positions at which enemy can be spawned in Vector3 format
    private Vector3[] EPos;

    //Settings object
    private Settings mode;

    //Current difficulty setting
    private string diff;

    //Enemies To Spawn
    private int ETS;

    //Enumerated position at which enemy will be spawned
    private int randDisplacement;

    //Random number which defines which position a enemy will spawn in
    private List<int> randNum;
    //-------------------------------------------------------------------------------

    private void Start()
    {
        //Enemy Positions
        EPos = new Vector3[] {
                                    new Vector3(-4, 3),
                                    new Vector3(3, 2.5f),
                                    new Vector3(-3, -4)
                                };


        //List containing the length of enemy positions as a list
        randNum = new List<int> { };

        //Fill list depending on size of EPos
        for (int i = 0; i < EPos.Length; i++) { randNum.Add(i); }

        //Get difficulty setting from Settings game object
        mode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        diff = mode.getDifficulty();



        //Set the Enemies To Spawn depending on the difficulty
        switch (diff)
        {
            case "easy":
                ETS = 1;
                break;

            case "medium":
                ETS = 2;
                break;

            case "hard":
                ETS = 3;
                break;
        }

        for (int i = 0; i < ETS; i++)
        {
            if (i == 0)
            {
                int rand = Random.Range(0, 100);

                if (rand > 20)
                {
                    // Choose randomly out of the predefined spawning locations
                    var index = Random.Range(0, randNum.Count);
                    randDisplacement = randNum[index];

                    spawnEnemy();
                    //Remove the position at which the enemy has just been spawned
                    randNum.RemoveAt(index);
                }
            }
            else if (i == 1)
            {
                int rand = Random.Range(0, 100);

                if (rand > 40)
                {
                    // Choose randomly out of the predefined spawning locations
                    var index = Random.Range(0, randNum.Count);
                    randDisplacement = randNum[index];

                    spawnEnemy();
                    //Remove the position at which the enemy has just been spawned
                    randNum.RemoveAt(index);
                }

            }
            else if (i == 2)
            {
                int rand = Random.Range(0, 100);

                if (rand > 70)
                {
                    // Choose randomly out of the predefined spawning locations
                    var index = Random.Range(0, randNum.Count);
                    randDisplacement = randNum[index];

                    spawnEnemy();
                    //Remove the position at which the enemy has just been spawned
                    randNum.RemoveAt(index);
                }
            }
        }
    }

    public void spawnEnemy()
    {


        //Spawn an enemy at position [random] of the array holding all positions
        Instantiate(enemyBase, transform.position + EPos[randDisplacement], Quaternion.identity);




    }
}
