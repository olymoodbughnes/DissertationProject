using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;

    [SerializeField]
    float detectRange;

    [SerializeField]
    PlayerMovementScript player1;

    Rigidbody2D rb;

    private Animator anim;

    private bool fallen = false;
    public CoinCollector scoring;
    public GameObject Score;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoring = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinCollector>();
    }
    void Update()
    {
        

        if (inSight(detectRange))
        {
            startFall();
        }

        if (fallen == true)
        {
            if (rb.velocity.y == 0)
            {
                anim.SetTrigger("Break");
            }


        }
        
    }

    public bool inSight(float range) {

        bool sighted = false;
        var castDist = range;

        Vector2 endPos = castPoint.position + new Vector3(0, -1, 0) * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));
        if (hit.collider != null)
        {


            if (hit.collider.CompareTag("Player"))
            {
                sighted = true;

                Debug.DrawLine(castPoint.position, hit.point, Color.yellow);

                
                Task.Delay(1000).ContinueWith(t => fallen = true);
            }
            else
            {
                sighted = false;
                
            }
        }

        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }
        return sighted;

    }


    public void startFall() {

        rb.isKinematic = false;
        rb.gravityScale = 3;
    }

    public void DestroySpike() {
        ShowScore();
        Destroy(this.gameObject);
    
    }

    private void ShowScore()
    {

        int rand = Random.Range(1, 3);
        int rand2 = 90;
        switch (rand)
        {
            case 1:
                rand2 = Random.Range(0, 90);
                break;

            case 2:
                rand2 = Random.Range(270, 360);
                break;

            case 3:
                rand2 = 0;
                break;
        }

        scoring.addScore();
        Instantiate(Score, transform.position + new Vector3(0, 0.2f, 0), Quaternion.Euler(0, 0, rand2));
    }

}
