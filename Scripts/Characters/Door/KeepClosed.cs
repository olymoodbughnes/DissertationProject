using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepClosed : MonoBehaviour
{

    [SerializeField]
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Closed() {

        anim.SetTrigger("KeepClosed");
    
    }
}
