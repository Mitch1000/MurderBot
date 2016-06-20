using UnityEngine;
using System.Collections;


public class Ground : MonoBehaviour
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
            newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x + 10.0f, ref velocity.x, smoothTime);
            newPos2D.y = 46.49f;
        }
        else
        {
            newPos2D.x = target.position.x + -10.0f;
            newPos2D.y = 46.49f;

        }


        Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);

        transform.position = Vector3.Slerp(transform.position, newPos, Time.time);

    }
}