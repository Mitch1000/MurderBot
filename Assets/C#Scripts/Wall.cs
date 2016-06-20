using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public Transform Camera;
    private Transform WallTransform;
    private Vector3 initialposition;

	// Use this for initialization
	void Start () {
        WallTransform = transform;
        initialposition = WallTransform.position;
	}



	// Update is called once per frame
	void Update () {

        if (WallTransform.position.x + 4.5f < Camera.position.x)
        {
            WallTransform.position = new Vector3(Camera.position.x - 4.5f, WallTransform.position.y);
        }

        if (Camera.position.x <  262.0f)
        {
            WallTransform.position = initialposition;
        }

	}
}
