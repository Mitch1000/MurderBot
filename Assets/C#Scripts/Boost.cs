using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {


    public GameObject MurderBot;
    public murderbotcontroller MurderBotScript;
    public PanCamerasInandOut MainCamera;
    public PanCamerasInandOut BackgroundCamea;
    public GameObject Arrow;
    public bool booston;
    public int numberofarrows;
    private int numberofarrowscreated;
    private float waittime;
    private GameObject newarrow;
    private bool cameraout;

	// Use this for initialization
	void Start () {
        booston = false;
        waittime = 0.2f;
        numberofarrowscreated = 1;
        cameraout = true;

	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 fwd = transform.TransformDirection(Vector3.up);
       // Debug.DrawRay(transform.position + new Vector3(-4.0f, 0.0f, 0.0f), fwd, Color.red, 100.0f);     
        if (MurderBot.transform.position.x > transform.position.x - 4.0f && MurderBot.transform.position.x < transform.position.x + 65.0f)
        {
            booston = true;
        }

        //Debug.DrawRay(transform.position + new Vector3(60.0f, 0.0f, 0.0f), fwd, Color.red, 100.0f);
        if (MurderBot.transform.position.x > transform.position.x + 65.0f || MurderBot.transform.position.x < transform.position.x - 4.0f)
        {
            booston = false;
        }
       
        waittime += Time.deltaTime;

        //"Boost" the Murderbot Along the Wood Platform
        if (booston == true)
        {         
            if (waittime > 0.02)
            {
                MurderBotScript.body.AddForce(new Vector3(7.0f, 0.0f, 0.0f), ForceMode2D.Impulse);            
                waittime = 0.0f;
            }
        }


        // Pan Cameras In and Out Once
        if (cameraout == true && booston == true)
        {
            MainCamera.PanOut();
            BackgroundCamea.PanOut();
            cameraout = false;

        }

        if (cameraout == false && booston == false)
        {
            MainCamera.PanIn();
            BackgroundCamea.PanIn();
            cameraout = true;
        }

        if (numberofarrowscreated < numberofarrows)
        {
            newarrow = Instantiate(Arrow);
            newarrow.transform.SetParent(gameObject.transform);
            newarrow.transform.localPosition = Arrow.transform.localPosition + new Vector3(numberofarrowscreated*20.0f, 0.0f, 0.0f);
            newarrow.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            numberofarrowscreated++;
        }

	}
}
