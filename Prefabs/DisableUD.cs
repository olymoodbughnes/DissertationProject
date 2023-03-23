using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUD : MonoBehaviour
{
    [SerializeField]
    PlatformEffector2D rbUP;

    [SerializeField]
    PlatformEffector2D rbDOWN;

    [SerializeField]
    DisableDF UPDoor;

    [SerializeField]
    DisableUF DOWNDoor;

    [SerializeField]
    GameObject Door;

    [SerializeField]
    ScoreKeeper sKeeper;

    private bool started = false;

    //Once player passes through front door, disable the other doors.

    private void Start()
    {
        rbUP = GameObject.FindGameObjectWithTag("UP").GetComponent<PlatformEffector2D>();
        rbDOWN = GameObject.FindGameObjectWithTag("DOWN").GetComponent<PlatformEffector2D>();

        UPDoor = GameObject.FindGameObjectWithTag("UP").GetComponent<DisableDF>();
        DOWNDoor = GameObject.FindGameObjectWithTag("DOWN").GetComponent<DisableUF>();

        sKeeper = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreKeeper>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player passes through front door.
        if (gameObject.tag == "FRONT" && started == false)
        {
            sKeeper.path("Mid");
            //Disable other doors
            GameObject.FindGameObjectWithTag("UP").tag = "NotActive";
            rbUP.enabled = false;
            UPDoor.CloseDoor();

            GameObject.FindGameObjectWithTag("DOWN").tag = "NotActive";
            rbDOWN.enabled = false;
            DOWNDoor.CloseDoor();
            started = true;
        }
    }

    public void CloseDoor()
    {
        started = true;
        Instantiate(Door, transform.position + new Vector3(-0.5f, -0.5f, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(Door, transform.position + new Vector3(-0.5f, -1.5f, 0), Quaternion.Euler(0, 0, 180));
    }
}
