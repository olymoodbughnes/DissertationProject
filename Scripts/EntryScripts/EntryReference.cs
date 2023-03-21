using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryReference : MonoBehaviour
{

    public Vector3 loc;
    public Vector3 cloc;
    public Vector3 clocM;
    public Vector3 clocB;
    public bool atStart = true;
    public bool atStartM = true;
    public bool atStartB = true;
    public SpawnExit spawner;
   
    // Start is called before the first frame update
    void Start()
    {
        
        loc = GameObject.FindGameObjectWithTag("EntryLocation").transform.position;
        spawner = GameObject.FindGameObjectWithTag("Start").GetComponent<SpawnExit>();
        spawner.spawnExit();

        print(loc);
        
        isAtStart(true);
        
    }

    public void setLoc(Vector3 current) {

        loc = current;
    
    }

    public void setCLoc(Vector3 current) {

        cloc = current;

    }    
    public void setCLocM(Vector3 current) {

        clocM = current;

    }    
    public void setCLocB(Vector3 current) {

        clocB = current;

    } 

    public Vector3 getLoc() {

        return loc;
    }

    public void isAtStart(bool t) {

        atStart = t;

    }  
    public void isAtStartM(bool t) {

        atStartM = t;

    }  
    public void isAtStartB(bool t) {

        atStartB = t;

    }

}
