using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{


    [SerializeField]
    Transform player;

    [SerializeField]
    float detectRange;

    [SerializeField]
    float sightRange;

    private Animator anim;


    [SerializeField]
    Transform castPoint;

    [SerializeField]
    float movementSpeed;

    Rigidbody2D rb;
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Rigidbody2D pRb;

    bool isFacingLeft;

    public GameObject Score;

    bool crushable = false;

    float heighDif;
    int a;
    bool crushed = false;

    public PlayerMovementScript player1;

    public CoinCollector scoring;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        sprite.color = new Color(r, g, b, 1f);
        a = 1;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //Get player as player1
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        pRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        scoring = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinCollector>();
         heighDif = Math.Abs(player1.transform.position.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

       

        heighDif = Math.Abs((player1.transform.position.y + 0.5f) - transform.position.y);

        if (heighDif > 1 || crushed == true)
        {
            gameObject.tag = "Crushable";
        }
        else
        {
            gameObject.tag = "Enemy";
        }
        //Distance to the player 
        float distToPlayer = Vector2.Distance(transform.position, player1.getPlayerPos());

        //If in sight then tackle
        if (inSight(sightRange))
        {


            tackleAttack();
        }

        else
        {

            //When player is not in sight but close enough (5) tackle
            if (distToPlayer < detectRange)
            {
                tackleAttack();
            }

            else

            {
                stopTackling();
            }

            stopTackling();
        }
    }

    bool inSight(float distance)
    {

        bool sighted = false;
        //Distance at which player can be sighted
        var castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }


        //Vector2 endPosHi = castPoint.position + new Vector3(0.5f, 1, 0) * castDist;
        //RaycastHit2D hitHi = Physics2D.Linecast(castPoint.position, endPosHi, 1 << LayerMask.NameToLayer("Action"));

        //Vector2 endPosUp = castPoint.position + new Vector3(0.8f, 0.5f, 0) * castDist;
        //RaycastHit2D hitUp = Physics2D.Linecast(castPoint.position, endPosUp, 1 << LayerMask.NameToLayer("Action"));

        Vector2 endPosMid = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hitMid = Physics2D.Linecast(castPoint.position, endPosMid, 1 << LayerMask.NameToLayer("Action"));

//        Vector2 endPosDown = castPoint.position + new Vector3(0.8f, -0.5f, 0) * castDist;
  //      RaycastHit2D hitDown = Physics2D.Linecast(castPoint.position, endPosDown, 1 << LayerMask.NameToLayer("Action"));

    //    Vector2 endPosLo = castPoint.position + new Vector3(0.5f, -1, 0) * castDist;
      //  RaycastHit2D hitLo = Physics2D.Linecast(castPoint.position, endPosLo, 1 << LayerMask.NameToLayer("Action"));



        //Detect at highest point
       /* if (hitHi.collider != null)
        {
            if (hitHi.collider.gameObject.CompareTag("Player"))
            {
                sighted = true;
            }

            else
            {
                sighted = false;
            }
        }

        //Detect at higher point
        if (hitUp.collider != null)
        {
            if (hitUp.collider.gameObject.CompareTag("Player"))
            {
                sighted = true;
            }

            else
            {
                sighted = false;
            }
        }
       */
        //Detect at middle point
        if (hitMid.collider != null)
        {
            if (hitMid.collider.gameObject.CompareTag("Player"))
            {
                sighted = true;
                Debug.DrawLine(castPoint.position, hitMid.point, Color.yellow);
            }

            else
            {
                sighted = false;
            }
        }

        else
        {
            Debug.DrawLine(castPoint.position, endPosMid, Color.blue);
        }

       /* //Detect at lower point
        if (hitDown.collider != null)
        {
            if (hitDown.collider.gameObject.CompareTag("Player"))
            {
                sighted = true;
            }

            else
            {
                sighted = false;
            }
        }

        //Detect at lowest point
        if (hitLo.collider != null)
        {
            if (hitLo.collider.gameObject.CompareTag("Player"))
            {
                sighted = true;
            }

            else
            {
                sighted = false;
            }
        }*/

        return sighted;
    }
       
    private void tackleAttack()
    {
        anim.SetBool("Agro", true);
        if (transform.position.x < player1.getPlayerPos().x)
        {
            //move right if player is to the right
            rb.velocity = new Vector2(movementSpeed, 0);
            transform.localScale = new Vector2(0.37f, 0.37f);
            isFacingLeft = false;
        }

        else

        {
            //move left if player is to the left
            rb.velocity = new Vector2(-movementSpeed, 0);
            transform.localScale = new Vector2(-0.37f, 0.37f);
            isFacingLeft = true;
        }
    }



    private void stopTackling()
    {
        anim.SetBool("Agro", false);
        rb.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (heighDif > 1 && a == 1)
            {

                crushed = true;
                pRb.velocity = new Vector2(0,13);
                
                    
                   
                    
                    anim.SetTrigger("Death");
                    

                a--;
            }
            
        }
    }
    public bool getCrushable ()
    {
        return crushable;
    }

    public void EnemyDeath()
    {
        ShowScore();
        Destroy(this.gameObject);
    }


    private void ShowScore() {

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
