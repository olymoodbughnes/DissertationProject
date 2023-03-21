using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitReference : MonoBehaviour
{


    public Vector3 loc;
    // Start is called before the first frame update
    void Start()
    {
        loc = GameObject.FindGameObjectWithTag("ExitLocation").transform.position;
        
    }


}
