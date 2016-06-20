using UnityEngine;
using System.Collections;


public class BackgroundCamera : MonoBehaviour
{


    public Transform target;
    public Transform BackgroundCameraTransform;
    public GameObject murderbotcontrol;
    public murderbotcontroller murderbot;
    public GameObject playplay;
    public Play Playtouch;
    private float smoothTime;
    private Vector2 velocity;
    private float yOffset;
    private bool useSmoothing;
    private bool panup;

    void Start()
    {
        velocity = new Vector2(0.5f, 0.5f);
        smoothTime = 0.3f;
        useSmoothing = true;
        yOffset = 0.1f;
        panup = true;
    }

    void Update()
    {

        if (murderbot.dead == true && Playtouch.playtouched == true)
        {
            if (panup == true)
            {
                panup = false;
                yOffset = 3.5f;
            }

        }

        else
        {
            panup = true;
            yOffset = 0.1f;
        }

            Vector2 newPos2D = BackgroundCameraTransform.position;
            if (useSmoothing)
            {
                //newPos2D.x = Mathf.SmoothDamp(BackgroundCameraTransform.position.x, target.position.x, ref velocity.x, smoothTime);
                newPos2D.y = Mathf.SmoothDamp(BackgroundCameraTransform.position.y, target.position.y + yOffset, ref velocity.y, smoothTime);

            }
            else
            {
                //newPos2D.x = target.position.x;
                newPos2D.y = target.position.y + yOffset;
            }


            Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPos, Time.time);

        }
    }
