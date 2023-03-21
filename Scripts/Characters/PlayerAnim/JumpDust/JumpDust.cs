using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDust : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void fadeDust() {

        Destroy(this.gameObject);
    
    }
}
