using UnityEngine;
using System.Collections;


public class SmoothFollowCamera : MonoBehaviour
 {
     public Transform FollowObject;
     public Transform BackgroundCameraTransform;
     public GameObject murderbotcontrol;
     public murderbotcontroller murderbot;
     public GameObject HomeScreen;
     public Play Playtouch;
     public bool IsBackgroundCamera;
     public float yOffset;
     public float smoothTime;
     private Transform thisTransform;
     private Vector2 velocity;
     private float waittime;
     private bool Enabled;
     private bool useSmoothing;
     private Vector2 newPos2D;
     private Vector3 target;
     private float moveforwarddistance;
     

     void Start()
     {

         velocity = new Vector2(0.5f, 0.5f);
         waittime = 0.0f;
         smoothTime = 0.3f;
         Enabled = false;
         useSmoothing = true;
         target = FollowObject.position;
         moveforwarddistance = 0.0f;

     }

   
     void Update()
     {

         #region Initial Pan to Character
         if (Playtouch.playtouched == true && IsBackgroundCamera == false && transform.position.x < 257.0f)
         {
             waittime += Time.deltaTime;
             if (waittime > 0.3f)
             {
                 Enabled = true;
             }
             smoothTime = 1.0f;

             if (waittime > 1.5f)
             {
                 smoothTime = 0.3f;
             }
         }
         #endregion

         #region Pan Up After Death
         if (murderbot.dead == true && Playtouch.playtouched == true)
         {           
                 yOffset = 3.5f;
                 moveforwarddistance = 0.0f;
                 target.x = FollowObject.position.x;
         }

         else
         {
             yOffset = 0.1f;
         }
         #endregion

         #region Smooth Follow
         if (Enabled == true || IsBackgroundCamera == true)
             {
                 
                 if (thisTransform.position.x + 0.001f > FollowObject.transform.position.x)
                 {
                     moveforwarddistance += Time.deltaTime * 0.3f;
                 }

                 else
                 {
                     moveforwarddistance = 0.0f;
                 }
                 target = new Vector3(FollowObject.position.x + moveforwarddistance, FollowObject.position.y);
             
             
                 //Set the Camera That This Script Will Be Modifying
                 if (IsBackgroundCamera == false)
                 {  
                     thisTransform = transform;
                     newPos2D = Vector2.zero;
                 }
                 else
                 {
                     thisTransform = BackgroundCameraTransform;
                     newPos2D = BackgroundCameraTransform.position;
                 }
                           

                 if (useSmoothing)
                 {
                    
                     //Do not Modify The X Position of the Background Camera
                     if (IsBackgroundCamera == false)
                     {
                        //Don't Allow The Camera To Move Backwards
                         if (murderbot.idleposition == 0 || FollowObject.position.x < 258.6)
                         {
                             newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, target.x, ref velocity.x, smoothTime);
                         }

                         else
                         {
                             newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, thisTransform.position.x, ref velocity.x, smoothTime);
                         }                                              
                     }
                        //Modify The X Position
                         newPos2D.y = Mathf.SmoothDamp(thisTransform.position.y, target.y + yOffset, ref velocity.y, smoothTime);
                     
                 }
                 else
                 {
                     //No Smoothing
                     //Do not Modify The X Position of the Background Camera
                     if (IsBackgroundCamera == false)
                     {
                         newPos2D.x = target.x;
                     }
                     
                     newPos2D.y = target.y + yOffset;
                 }

                 Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);
                 transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
                      
             }
          #endregion
     }
 }