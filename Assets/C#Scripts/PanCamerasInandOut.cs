using UnityEngine;
using System.Collections;

public class PanCamerasInandOut : MonoBehaviour {
    public Camera PanCamera;
    public SmoothFollowCamera PanCameraScript;
    private float panouttime;
    private float panintime;
    private float storedsize;
    private bool storestateout;
    private bool storestatein;
    private bool panincomplete;
    private bool panoutcomplete;

	// Use this for initialization
	void Start () 
    {
        panouttime = 0.0f;
        panintime = 0.0f;
        storestateout = true;
        storestatein = true;
        panincomplete = true;
        panoutcomplete = true;
	}

    void PanOutFunction()
    {
        
        if (panouttime < 1.0f)
        {
            panouttime += Time.deltaTime * 1.5f;
            panoutcomplete = false;

        }
        else
        {
            panoutcomplete = true;
            panintime = 0.0f;
        }

        PanCamera.orthographicSize = Mathf.Lerp(4.951524f, 9f, panouttime);
        PanCameraScript.smoothTime = Mathf.Lerp(0.3f, 0.0f, panouttime);
        PanCameraScript.yOffset = Mathf.Lerp(0.1f, 2.5f, panouttime);
    }

    void PanInFunction()
    {
    
        if (panintime < 1.0f)
        {
            panintime += Time.deltaTime * 1.5f;
            panincomplete = false;

        }
        else
        {
            panincomplete = true;
            panouttime = 0.0f;
        }
        
        PanCamera.orthographicSize = Mathf.Lerp(9f, 4.951524f, panintime);
        PanCameraScript.smoothTime = Mathf.Lerp(0.0f, 0.3f, panintime);
        PanCameraScript.yOffset = Mathf.Lerp(2.5f, 0.1f, panintime); 

    }

    public void PanIn()
    {
        panincomplete = false;
    }

    public void PanOut()
    {
        panoutcomplete = false;
    }

	// Update is called once per frame
	void Update () {
        #region PanIn and Out



            if (panoutcomplete == false)
            {
                PanOutFunction();
            }


            if (panincomplete == false)
            {
                PanInFunction();
            }

        #endregion
	}
}
