using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoomBot : MonoBehaviour
{
    
    public int doorOrientation;
    private Vector3 startRef;
    private Vector3 ownRef;
    private Vector3 endRef;
    private RoomTemplateBot templates;
    private EntryReference startRoom;
    private ExitReference endRoom;
    private CLocation currentRoom;
    private int rand;
    private bool spawned = false;
    private bool starting = true;
    //current block distance from entry
    private double height;
    private double width;

    private double heightToEnd;
    private double widthToEnd;
    //test variable
    public int count;

    private void Start()
    {

        templates = GameObject.FindGameObjectWithTag("BottomRooms").GetComponent<RoomTemplateBot>();

        //Start room location


        startRoom = GameObject.FindGameObjectWithTag("Start").GetComponent<EntryReference>();
       


        ownRef = startRoom.clocB;
        startRef = startRoom.loc;
     


        InvokeRepeating("Spawn", 0.1f, 0.1f);
    }

    private void Spawn()
    {

        endRoom = GameObject.FindGameObjectWithTag("Finish").GetComponent<ExitReference>();
        //refresh locations of reference points
        ownRef = startRoom.clocB;
        startRef = startRoom.loc;
        endRef = endRoom.loc;

        print(starting + " == " + startRoom.atStart);
        starting = startRoom.atStartB;
        //calculate height and width
        height = System.Math.Abs(startRef.y - ownRef.y);
        width = System.Math.Abs(startRef.x - ownRef.x);

        //calculate height and width to end

        heightToEnd = System.Math.Abs(endRef.y - ownRef.y);
        widthToEnd = System.Math.Abs(endRef.x - ownRef.x);

        //print("Latest block: " + ownRef + "Starting block: " + startRef);
        print("current top block height: " + height);
        print("current top block width: " + width);
        print("Distance to end: " + widthToEnd);
        if (spawned == false)
        {
            //spawn blocks upwards

            //if height is less than 40 blocks away
            if (doorOrientation == 3)
            {

                if (widthToEnd == 20)
                {
                    rand = Random.Range(0, templates.topRooms3.Length);
                    Instantiate(templates.topRooms3[rand], transform.position, Quaternion.identity);
                    spawned = true;
                    return;
                }
                if (starting == true)
                {
                    rand = Random.Range(0, templates.bottomRooms3.Length);
                    Instantiate(templates.bottomRooms3[rand], transform.position, Quaternion.identity);
                    spawned = true;
                    startRoom.isAtStartB(false);
                    return;
                }

                if (height < 40)
                {

                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                }
                //if height is beyond 40 blocks away
                else if (height > 50)
                {
                    rand = Random.Range(0, templates.topRooms3.Length);
                    Instantiate(templates.topRooms3[rand], transform.position, Quaternion.identity);
                    spawned = true;

                }
                else if (height >= 40)
                {
                    rand = Random.Range(0, templates.topRooms2.Length);
                    Instantiate(templates.topRooms2[rand], transform.position, Quaternion.identity);
                }




            }


            if (doorOrientation == 2)
            {


                if (widthToEnd == 10)
                {
                    rand = Random.Range(0, templates.rightRooms3.Length);
                    Instantiate(templates.rightRooms3[rand], transform.position, Quaternion.identity);
                    spawned = true;
                    return;
                }


                if (height < 40)
                {

                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                }

                else if (height > 50)
                {
                    rand = Random.Range(0, templates.rightRooms3.Length);
                    Instantiate(templates.rightRooms3[rand], transform.position, Quaternion.identity);
                    spawned = true;

                }

                else if (height >= 40)
                {

                    rand = Random.Range(0, templates.rightRooms2.Length);
                    Instantiate(templates.rightRooms2[rand], transform.position, Quaternion.identity);
                }


            }

            if (doorOrientation == 1)
            {

                if (widthToEnd == 0)
                {


                    if (heightToEnd == 10)
                    {
                        return;
                    }

                    rand = Random.Range(0, templates.bottomRooms3.Length);
                    Instantiate(templates.bottomRooms3[rand], transform.position, Quaternion.identity);
                    spawned = true;
                    return;
                }


                if (height < 40 && width != 0)
                {


                    rand = Random.Range(0, templates.bottomRooms2.Length);
                    Instantiate(templates.bottomRooms2[rand], transform.position, Quaternion.identity);

                }
                else if (height >= 40)
                {


                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);

                }
            }



            spawned = true;
        }

    }


    private void OnTriggerEnter2D(Collider2D otherRoom)
    {
        if (otherRoom.CompareTag("SpawnPointBot")  && otherRoom.GetComponent<SpawnRoomBot>().spawned == true)
        {
            Destroy(gameObject);
        }

    }

    public void setOwnRef(Vector3 current)
    {

        ownRef = current;
        print("ownRef Updated: " + count);
        count++;

    }

    public void setStartRef(Vector3 current)
    {

        startRef = current;


    }
    public void setHeight(double current)
    {

        height = current;


    }
    public void setWidth(double current)
    {

        width = current;


    }


    public bool getSpawned()
    {

        return spawned;
    }

}
