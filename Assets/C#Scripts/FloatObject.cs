using UnityEngine;
using System.Collections;

public class FloatObject : MonoBehaviour {

    public RectTransform ObjectThatFloats;
    public float FloatDistance;
    public bool FalseForUpDownDirection;
    public float speed;
    private Vector3 initialposition;   
    private float changeintime;
    private float direction;
    private bool up;
    private Vector3 movevector;
	// Use this for initialization
	void Start () {

        initialposition = ObjectThatFloats.anchoredPosition;
        changeintime = 0.0f;
        direction = 1.0f;
        up = true;
	}
	
	// Update is called once per frame
	void Update () {
        changeintime += Time.deltaTime * direction;

        if (FalseForUpDownDirection == false)
        {
            movevector = new Vector3(0.0f, (changeintime * speed));
        }

        else
        {
            movevector = new Vector3((changeintime * speed), 0.0f);
        }
       
        
        if (changeintime <= FloatDistance && up == true)
        {
            ObjectThatFloats.anchoredPosition =  initialposition + movevector;
        }

        else
        {
            direction = -1.0f;
            up = false;
        }

        //Move Down
        if (changeintime >= (FloatDistance * -1) && up == false)
        {
            ObjectThatFloats.anchoredPosition = initialposition + movevector;
        }

        else
        {
            direction = 1.0f;
            up = true;
        }

	
	}
}
