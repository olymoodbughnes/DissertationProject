using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDF : MonoBehaviour
{
    [SerializeField]
    PlatformEffector2D rbDOWN;

    [SerializeField]
    PlatformEffector2D rbFRONT;

    [SerializeField]
    DisableUF DOWNDoor;

    [SerializeField]
    DisableUD FRONTDoor;

    [SerializeField]
    GameObject Door;

    [SerializeField]
    ScoreKeeper sKeeper;
    private bool started = false;
    private void Start()
    {
        rbDOWN = GameObject.FindGameObjectWithTag("DOWN").GetComponent<PlatformEffector2D>();
        rbFRONT = GameObject.FindGameObjectWithTag("FRONT").GetComponent<PlatformEffector2D>();

        DOWNDoor = GameObject.FindGameObjectWithTag("DOWN").GetComponent<DisableUF>();
        FRONTDoor = GameObject.FindGameObjectWithTag("FRONT").GetComponent<DisableUD>();

        sKeeper = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreKeeper>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.tag == "UP" && started == false)
            
        {
            sKeeper.path("Up");
            GameObject.FindGameObjectWithTag("DOWN").tag = "NotActive";
            rbDOWN.enabled = false;
            DOWNDoor.CloseDoor();
            GameObject.FindGameObjectWithTag("FRONT").tag = "NotActive";
            rbFRONT.enabled = false;
            FRONTDoor.CloseDoor();

            started = true;

        }
        

    }

    public void CloseDoor()
    {
        started = true;
        Instantiate(Door, transform.position + new Vector3(0.5f, -0.5f, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(Door, transform.position + new Vector3(1.5f, -0.5f, 0), Quaternion.Euler(0, 0, 270));

    }
}
