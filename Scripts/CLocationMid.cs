using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLocationMid : MonoBehaviour
{
    public Vector3 cloc;
    private Vector3 startRef;
    private EntryReference startRoom;
    private SpawnRoomMid spawner;
    private double height;
    private double width;

    void Start()
    {
        //current location
        cloc = transform.position;


        //send current location to spawnpoint
        spawner = GameObject.FindGameObjectWithTag("SpawnPointMid").GetComponent<SpawnRoomMid>();
        //spawner.setOwnRef(cloc);


        //start room location
        startRoom = GameObject.FindGameObjectWithTag("Start").GetComponent<EntryReference>();

        startRef = startRoom.loc;



        //calculate height and width of latest block

        startRoom.setCLocM(cloc);
        //startRoom.setLoc(startRef);





        /*start room location
        

        print("startref: " + startRef);
        */

        

    }
}
