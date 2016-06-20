using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {
    public int frames = 0;
    public bool direction = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (direction == false)
        {
            transform.position += Vector3.left * 0.2f * Time.deltaTime;
        }

        else
        {
            transform.position += Vector3.right * 0.2f * Time.deltaTime;
        }

   

        if (frames == 3800 && direction == false)
        {
            direction = true;
            frames = 0;
        }

        else if (frames == 3800 && direction == true)
        {
            direction = false;
            frames = 0;
        }

        frames++;

	}
}
