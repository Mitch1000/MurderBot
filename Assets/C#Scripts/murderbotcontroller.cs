using UnityEngine;
using System.Collections;


public class murderbotcontroller : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D body;
    public GameObject murderbot;
    //movement speeds
    public float speed;
    public float verticalspeed;
    public float jumpgravity;
    //for idle position
    public int idleposition;
    //for ground detection
    public bool IsGrounded;
    // for collision detection
    private bool StopMoving;
    //For Death
    public bool dead;
    public bool initialized;
    public androidinput andriodin;
    public Collider2D botcollider;
    public int colliderid;
    public System.Type targetid;
    public GameObject androidcontrol;
    public int armdirection;
    public Boost BoostScript;
    private RuntimePlatform platform = Application.platform;
    private Vector2 startposition;
    //for andoid input  
    private Vector2 touchposition;
    private float changeintime;
    private Vector2 differencevector;
    private float moveorleftright;
    private bool IsColliding;
    private bool CollidedStop;
    // for moving in air
    private float airmoved;
    private bool forcedjump;
    public bool noclip;



    //Debug.Log("airmoved: " + airmoved);
    //Debug.Log("Grounded: " + IsGrounded);


    void Start()
    {
        idleposition = 0;
        airmoved = 0.0f;
        armdirection = 4;
        andriodin.touchPosition.x = body.position.x;       
        startposition = new Vector2(258.59f, 51.68f);
        IsColliding = false;
        IsGrounded = false;
        dead = true;
        initialized = true;
                  
    }



    void OnCollisionStay2D(Collision2D target)
    {
  //Kill MurderBotIf He Hits a Spike or Is Drowning
            if (target.gameObject.tag == "Drown" || target.gameObject.tag == "Spike" )
            {
                body.velocity = Vector3.zero;
                body.angularVelocity = 0.0f;
                dead = true;
                IsColliding = true;
                IsGrounded = true;

            }

            if (target.gameObject.tag == "Ground")
            {
                IsGrounded = true;
            }

           IsColliding = true;
  
    }

    //Bounce If On Jelly
    void Bounce(Collision2D target)
    {

            if (target.gameObject.tag.Equals("Bounce"))
            {
                andriodin.swipeup = true;
                andriodin.swipeuplength = 65.0f;
                IsGrounded = true;
            }

            if (target.gameObject.tag.Equals("DoubleBounce"))
            {
                andriodin.swipeup = true;
                andriodin.swipeuplength = 130.0f;
                IsGrounded = true;
                forcedjump = true;
            }

    }



    void OnCollisionEnter2D(Collision2D target)
    {      
        //Calculate Where
        Vector3 hit = target.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);
        forcedjump = false;
        if (angle < 40)
        {
            Bounce(target);
        }
        
        IsColliding = true;
        body.velocity = new Vector3(0.0f, 0.0f, 0.0f);

    }


    void OnCollisionExit2D(Collision2D target)
    {
        IsColliding = false;
        IsGrounded = false;
    }



    //All the Physics related things to be done here
    void FixedUpdate()
    {
        //If noclip is false add the force of gravity
        if (noclip == false)
        {
            body.AddForce(new Vector2(0, -60.0f), ForceMode2D.Force);

        }
        else
        {
            body.gravityScale = 0.0f;
        }

    }



    // Update is called once per frame
    void Update()
    {

        if (noclip == true)
        {
            botcollider.enabled = false;
            IsColliding = true;
            IsGrounded = true;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                body.AddForce(new Vector3(0.0f, -120.0f));
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.AddForce(new Vector3(0.0f, 120.0f));
            }
        }


        if (initialized == true)
        {
            dead = true;          
        }

        // touchposition.x = body.position.x;
        if (andriodin.swipeleftlength > 110.0f)
        {
            andriodin.swipeleftlength = 110.0f;
        }

        if (andriodin.swiperightlength > 110.0f)
        {
            andriodin.swiperightlength = 110.0f;
        }

        if (forcedjump == false)
        {
            if (andriodin.swipeuplength > 75.0f)
            {
                andriodin.swipeuplength = 75.0f;
            }
        }
        
        if (andriodin.time == true)
        {
            changeintime = Time.time;
            andriodin.time = false;
        }



        if (IsGrounded == true)
        {
            //jump 
            if (Input.GetKey(KeyCode.Space) || andriodin.swipeup == true)
            {

                body.AddForce(new Vector2(0, verticalspeed * andriodin.swipeuplength * 0.1f), ForceMode2D.Impulse);
                //andriodin.doubletaped = false;
                andriodin.swipeup = false;
                airmoved = 0.0f;

                //Jump Facing Left
                if (idleposition == 1)
                {
                    animator.SetInteger("Direction", 2);
                    armdirection = 5;
                }

                //Jump Facing Right
                else if (idleposition == 0)
                {
                    animator.SetInteger("Direction", 3);
                    armdirection = 4;
                }
                IsGrounded = false;
            }

        }

        else
        {
            andriodin.swipeup = false;
        }
     
            //Move in Air
            if ((IsGrounded == false) && airmoved < 330.0f )
            {

                //Move Left in Air
                if ((Input.GetKey(KeyCode.LeftArrow) || andriodin.swipeleft == true) && BoostScript.booston == false)
                {
                    animator.SetInteger("Direction", 1);
                    body.AddForce(new Vector2(andriodin.swipeleftlength * speed * -1, 0), ForceMode2D.Impulse);
                    idleposition = 1;
                    airmoved += andriodin.swipeleftlength * -1.0f;
                    andriodin.swipeleft = false;
                    armdirection = 5;
                }

                //Move Right in Air
                else if (Input.GetKey(KeyCode.RightArrow) || andriodin.swiperight == true)
                {
                    animator.SetInteger("Direction", 0);
                    body.AddForce(new Vector2(andriodin.swiperightlength * speed, 0), ForceMode2D.Impulse);
                    idleposition = 0;
                    andriodin.swiperight = false;
                    airmoved += andriodin.swipeleftlength;
                    armdirection = 4;
                }

            }
        


        // Set Idle Position Based on Previous Movement
   
            if (idleposition == 0)
            {
                animator.SetInteger("Direction", 4);
            }

            else if (idleposition == 1)
            {
                animator.SetInteger("Direction", 5);
            }

            #region Slide Move
            //Slide Left
        if(IsColliding == true && IsGrounded == true)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || andriodin.swipeleft == true ) && BoostScript.booston == false)
            {
                animator.SetInteger("Direction", 1);
                idleposition = 1;
                armdirection = 5;
                andriodin.swipeleft = false;
                CollidedStop = true;
                StopMoving = true;
                body.AddForce(new Vector2(andriodin.swipeleftlength * speed * -1.5f, 0), ForceMode2D.Impulse);
                andriodin.touchPosition.x = body.position.x;


            }
            //Slide Right
            else if (Input.GetKey(KeyCode.RightArrow) || andriodin.swiperight == true)
            {
                animator.SetInteger("Direction", 0);
                idleposition = 0;
                armdirection = 4;
                andriodin.swiperight = false;
                CollidedStop = true;
                StopMoving = true;
                body.AddForce(new Vector2(andriodin.swiperightlength * speed * 1.5f, 0), ForceMode2D.Impulse);
                andriodin.touchPosition.x = body.position.x;

            }
        }
            #endregion


            #region Click On Point Move
            differencevector.x = Mathf.Abs(andriodin.touchPosition.x - body.position.x);
            moveorleftright = Mathf.Sign(andriodin.touchPosition.x - body.position.x);


            if (CollidedStop == true)
            {

                andriodin.touchPosition.x = body.position.x;
                CollidedStop = false;

            }


            if (IsColliding == true && IsGrounded == true)
            {
                if (StopMoving == false)
                {
                    //Move Left
                    if (((differencevector.x > 1.0f && moveorleftright < 0) && andriodin.swipeleft == false ) && BoostScript.booston == false)
                    {
                        animator.SetInteger("Direction", 1);
                        idleposition = 1;
                        armdirection = 5;
                        body.AddForce(new Vector2(-10.0f * speed, 0), ForceMode2D.Impulse);
                    }
                    //Move Right
                    else if ((differencevector.x > 0.3f && moveorleftright > 0) && andriodin.swiperight == false)
                    {
                        animator.SetInteger("Direction", 0);
                        idleposition = 0;
                        armdirection = 4;
                        body.AddForce(new Vector2(10.0f * speed, 0), ForceMode2D.Impulse);


                    }

                }

            }

            else
            {
                andriodin.touchPosition.x = body.position.x;
            }
            #endregion


    }

}
