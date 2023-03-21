using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject JumpDust;
    public GameObject TurnLeftDust;
    public GameObject TurnRightDust;
    float horizontalIput;
    float verticalInput;
    private Vector3 playerPos;
    private Animator anim;
    //This is how fast player moves
    public float moveSpeed = 7;
    private bool jumped;
    
    //This is the force behind every jump
    public float jumpForce = 10f;
  
    //Stealth mode 
    bool stealth = false;

 
   
    void Start()
    {
        anim = GetComponent<Animator>();
      

       

       
        rb = GetComponent<Rigidbody2D>();
       

    }

    private void Awake()
    {
       rb = transform.GetComponent<Rigidbody2D>();
    }
   
    private void FixedUpdate()
    {

        //get user input

        horizontalIput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

       
       

        //move ass
        rb.velocity = new Vector2(horizontalIput * moveSpeed, rb.velocity.y);
        //rb.velocity = new Vector2(rb.velocity.x, verticalInput * moveSpeed);



      
    }
    private void Update()
    {
        
        playerPos = transform.position;


        if (rb.velocity.y == 0)
        {
            anim.SetBool("Falling", false);
            anim.SetTrigger("Landed");
           
            jumped = false;

        }

        if (rb.velocity.y < -0.1)
        {

            anim.SetBool("Falling", true);
            jumped = false;

        }
        else
        {

        }

        //player 
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0")) 
        {
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(JumpDust, transform.position + new Vector3( 0, 0.2f,0), Quaternion.identity);
            anim.SetTrigger("Jump");
            jumped = true;
        }

        if (Input.GetKeyDown("d"))
        {
            anim.SetBool("Walking", true);
            Instantiate(TurnRightDust, transform.position + new Vector3(-0.4f, 0.1f, 0), Quaternion.identity);
        }

        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("Walking", false); ;
        }

        if (Input.GetKeyDown("a"))
        {
            Instantiate(TurnLeftDust, transform.position + new Vector3(0.4f, 0.1f, 0), Quaternion.identity);
            anim.SetBool("WalkingL", true);
        }

        if (Input.GetKeyUp("a"))
        {
           

            anim.SetBool("WalkingL", false); ;
        }


        if (Input.GetKeyDown("joystick button 5"))
        {
            moveSpeed = moveSpeed / 2;
            jumpForce = jumpForce / 2;
            stealth = false;

        }
        else if(Input.GetKeyUp("joystick button 5"))
        { 
            moveSpeed = moveSpeed * 2;
            jumpForce = jumpForce * 2;
       
        }

         if (Input.GetKeyDown("joystick button 4"))
        {
           
            moveSpeed = moveSpeed * 2;

        }
        else if(Input.GetKeyUp("joystick button 4"))
        {
            moveSpeed = moveSpeed / 2;


        }

      


    }

    public Vector3 getPlayerPos() {
        playerPos = transform.position;
        return playerPos;
    
    }


    public void setPlayerPos(Vector3 newPos)
    {

        playerPos = newPos;

    }

}
