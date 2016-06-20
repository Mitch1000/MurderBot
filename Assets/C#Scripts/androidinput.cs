using UnityEngine;
using System.Collections;

public class androidinput : MonoBehaviour
{
    public bool swipeleft;
    public bool swiperight;
    public bool swipeup;
    public bool swipedown;
    public bool murderbottouched;
    public float swipeleftlength;
    public float swiperightlength;
    public float swipedownlength;
    public float swipeuplength;
    public float minSwipeDistY;
    public float minSwipeDistX;
    public bool time;
    public murderbotcontroller murderbotcontrol;
    public GameObject murderbot; 
    public Vector3 touchPosition;
    public Vector3 doubletaptouchPosition;
    public bool doubletaped;
    private float doubletaptime;
    private Vector2 startPos;
    private RuntimePlatform platform = Application.platform;



    //void checkTouch(Vector3 pos)
    //{
    //    Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
    //    Vector2 touchPos = new Vector2(wp.x, wp.y);
    //    Collider2D hit = Physics2D.OverlapPoint(touchPos);

    //     if (hit)
    //    {

        
    //    //hit.transform.gameObject.SendMessage("Clicked", 0, SendMessageOptions.DontRequireReceiver);
    //    }
    //}



    // Use this for initialization
    void Start()
    {
        swipedown = false;
        swipeup = false;
        swiperight = false;
        swipeleft = false;
        murderbottouched = true;
        doubletaped = false;
        touchPosition = murderbotcontrol.body.position;
    }

    // Update is called once per frame
    void Update()
    {

        doubletaped = false;

        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                time = true;
                #region double touch jump/ slide move

                //if (Input.GetTouch(0).phase == TouchPhase.Moved)
                //{
                //    // Get movement of the finger since last frame
                //    touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                //}


                //if ((Input.GetTouch(0).phase == TouchPhase.Ended) && touchDeltaPosition.x < 0.3f)
                //{

                //    if (Time.time < doubletaptime + 0.3f)
                //    {
                //        doubletaped = true;
                //    }
                //    doubletaptime = Time.time;


                //    if (doubletaped == true)
                //    {
                //        checkTouch(Input.GetTouch(0).position);     
                //    }

                //}
                #endregion


                #region swipe inputs
                // Swipe Inputs
                Touch touch = Input.touches[0];
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = touch.position;
                        break;
                    case TouchPhase.Ended:

                        //Swipe Left and Right
                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                        if (swipeDistHorizontal > minSwipeDistX)
                        {
                            float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                            if (swipeValue > 0)//right swipe
                            {
                                swiperightlength = swipeDistHorizontal;
                                swiperight = true;

                            }
                            else if (swipeValue < 0)//left swipe
                            {
                                swipeleftlength = swipeDistHorizontal;
                                swipeleft = true;

                            }
                        }

                        //Swipe Up and Down
                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                        if ((swipeDistVertical > minSwipeDistY) && swiperight == false && swipeleft == false)
                        {
                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                            if (swipeValue > 0 && swipeup == false)//up swipe
                            {
                                swipeup = true;
                                swipeuplength = swipeDistVertical;
                            }
                            else if (swipeValue < 0)//down swipe
                            {
                                swipedown = true;
                                swipedownlength = swipeDistVertical;

                            }

                        }

                        break;
                }
             
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {

                    touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    
                    //Double Tap
                    if (Time.time < doubletaptime + 0.3f)
                    {
                        doubletaped = true;
                    }
               
                    else
                    {
                        doubletaped = false;
                        doubletaptouchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                    }

                    doubletaptime = Time.time;

                }


            }

            else
            {
                time = false;
            }

        }
                #endregion

        else if (platform == RuntimePlatform.WindowsEditor)
        {

            swipedownlength = 10.0f;
            swipeuplength = 140.0f;
            swiperightlength = 15.0f;
            swipeleftlength = 15.0f;

            if (Input.GetMouseButtonDown(0))
            {

                touchPosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
                
                if (Time.time < doubletaptime + 0.3f)
                {
                    doubletaped = true;
                }
        

                else
                {
                   doubletaptouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                doubletaptime = Time.time;
                time = true;
            }


        }
    }
}