using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLocation : MonoBehaviour
{
    public Vector3 cloc;
    private Vector3 startRef;
    private EntryReference startRoom;
    private SpawnRoom spawner;
    private double height;
    private double width;

    void Start()
    {
        //current location
        cloc = transform.position;
        print("New current location" + cloc);

        //send current location to spawnpoint
        spawner = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawnRoom>();
        spawner.setOwnRef(cloc);


        //start room location
        startRoom = GameObject.FindGameObjectWithTag("Start").GetComponent<EntryReference>();

        


        //calculate height and width of latest block
       
        startRoom.setCLoc(cloc);




    }
}
