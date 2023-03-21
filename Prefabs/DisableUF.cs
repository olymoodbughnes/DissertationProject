using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUF : MonoBehaviour
{
    [SerializeField]
    PlatformEffector2D rbUP;

    [SerializeField]
    PlatformEffector2D rbFRONT;

    [SerializeField]
    DisableDF UPDoor;

    [SerializeField]
    DisableUD FRONTDoor;

    [SerializeField]
    GameObject Door;

    [SerializeField]
    ScoreKeeper sKeeper;

    private bool started = false;
    private void Start()
    {
        rbUP = GameObject.FindGameObjectWithTag("UP").GetComponent<PlatformEffector2D>();
        rbFRONT = GameObject.FindGameObjectWithTag("FRONT").GetComponent<PlatformEffector2D>();

        UPDoor = GameObject.FindGameObjectWithTag("UP").GetComponent<DisableDF>();
        FRONTDoor = GameObject.FindGameObjectWithTag("FRONT").GetComponent<DisableUD>();

        sKeeper = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreKeeper>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "DOWN" && started == false)
        {
            sKeeper.path("Down");
            GameObject.FindGameObjectWithTag("UP").tag = "NotActive";
            rbUP.enabled = false;
            UPDoor.CloseDoor();
            GameObject.FindGameObjectWithTag("FRONT").tag = "NotActive";
            rbFRONT.enabled = false;
            FRONTDoor.CloseDoor();

            started = true;
        }
      
    }

    public void CloseDoor(){
        started = true;
        Instantiate(Door, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 270));
        Instantiate(Door, transform.position + new Vector3(-1.5f, 0.5f, 0), Quaternion.Euler(0, 0, 90));


    }
}
