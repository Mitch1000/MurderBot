using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

    public RectTransform PlayText;
    public CanvasRenderer PlayRender;
    public GameObject PlayObject;  
    //For When Menu Button is Pressed
    public GameObject GameOverCanvas;
    public GameObject GameOverObject;
    public GameOver gameover;
    public GameObject MainCamera;
    public GameObject BackgroundCamera;
    public Transform murderbot;
    public Transform MurderBotArm;
    public FloatObject PlayFloat;
    public float floatdistance;
    public bool playtouched;
    private float changeintime;
    private float switchdirection;
    private bool up;
    


	// Use this for initialization
	
    
    
    void Start () {
        
        changeintime = 0.0f;
        switchdirection = -1.0f;
        up = true;
        PlayRender.SetAlpha(0.5f);
        playtouched = false;
  
	}

    public void playbuttonpressed()
    {
        playtouched = true;     
    }

    public void playbuttonselected()
    {
        PlayRender.SetAlpha(0.7f);
    }

	void Update () 
    {


   

        if(playtouched == true)
        {
            Destroy(PlayFloat);
            changeintime += Time.deltaTime * 20.0f;
        
            if (changeintime < 6.0f)
            {
                PlayText.position += new Vector3(0, changeintime);

            }
            else
            {
                PlayText.position += new Vector3(0, changeintime * -1.0f);

            }
            
            if (MainCamera.transform.position.x < 255.5f)
            {
                murderbot.position = new Vector3(258.58f, 53.55f, 0.0f);
                MurderBotArm.position = new Vector3(258.53f, 53.58f, 0.0f);
            }


        }

        if (gameover.menubuttonclicked == true)
        {
     
            MainCamera.transform.position = new Vector3(250.51f, 52.63f, -1.5f);
            BackgroundCamera.transform.position = new Vector3(250.51f, 52.63f, -1.5f);
            changeintime = 0.0f;
            switchdirection = -1.0f;
            playtouched = false;
            PlayText.anchoredPosition = new Vector3(-3.0f, 41.0f);

        }

	}
}
