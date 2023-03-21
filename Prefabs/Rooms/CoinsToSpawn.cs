using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsToSpawn : MonoBehaviour
{

    public int CoinsLeftToSpawn;
    public string diff;
    public GameObject coins;
    public GameObject thisone;
    private int rand;
    private int randDisplacement;
    private Vector3 spawnPoint;
    private Settings mode;
    private string places;
    private CoinSpawnPointSpawned status;
    private bool spawned;
   




    public bool a;
    public bool b;
    public bool c;
    private void Start()
    {
        spawned = false;
        //spawnPoint = GameObject.FindGameObjectWithTag("CoinSpawnMiddle").transform.position;
        //places = GameObject.FindGameObjectWithTag("CoinPlaces").GetComponent<CoinSpawnPoints>().SpawnPoints();
        status = GameObject.FindGameObjectWithTag("CoinSpawn").GetComponent<CoinSpawnPointSpawned>();
        mode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();







        
           
 
            
  


    }

    /*
     * 
     * 
     for (int i; i = coinslefttospawn; i--){
     while(spawned == false){
    
        choose random spawner

        rand = allspawnpoints
        spawn at rand
        spawned = coinspawnppointspawned.spawned();
        
        
    }
        coinspawnpoints[rand].spawned() == false;
        spawned = false;
     
     }
     */
}
