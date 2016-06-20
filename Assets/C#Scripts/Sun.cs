using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
    public Transform SunTransform;
    public Transform Shader;
    private float changeintime;
    private Vector3 currentlocation;
    private Vector3 shadercurrentlocation;

	// Use this for initialization
	void Start () {
        changeintime = 0.0f;
        currentlocation = SunTransform.position;
        shadercurrentlocation = Shader.position;
  

	}
	
	// Update is called once per frame
	void Update () {

        if (changeintime < 7.5f)
        {
            changeintime += Time.deltaTime * -0.02f;
            SunTransform.position = currentlocation + new Vector3(0.0f, changeintime, 0.0f);
            Shader.position = shadercurrentlocation + new Vector3(0.0f, changeintime, 0.0f);
        }

	}
}
