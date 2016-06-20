using UnityEngine;
using System.Collections;


public class Scroll : MonoBehaviour
{


    public Transform target;
    public float smoothTime;
    private Transform thisTransform;
    private Vector2 velocity;
    public float yOffset;

    public bool useSmoothing = false;
    void Start()
    {
        thisTransform = transform;
        velocity = new Vector2(0.5f, 0.5f);
    }

    void Update()
    {
        Vector2 newPos2D = Vector2.zero;
        if (useSmoothing)
        {
            newPos2D.x = 254.77f;
            newPos2D.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y + yOffset, ref velocity.y, smoothTime);
        }
        else
        {
            newPos2D.x = 250.51f;
            newPos2D.y = target.position.y + yOffset;

        }


        Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);

        transform.position = Vector3.Slerp(transform.position, newPos, Time.time);

    }
}