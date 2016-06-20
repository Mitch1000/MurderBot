using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {
    

    public GameObject murderbotcontrol;
    public murderbotcontroller murderbot;
    public GameObject DistanceGameObject;
    public DistanceText Distance;
    public GameObject GameOverScreen;
    public GameObject PlayObject;
    public Text EndScore;
    public Text Best;
    public CanvasRenderer EndScoreRender;
    public CanvasRenderer BestRender;
    public CanvasRenderer ReplayRender;
    public Transform MurderBotArm;
    public bool menubuttonclicked;
    public bool replaybuttonclicked;
    private float bestscore;





	// Use this for initialization
	void Start () {
    ReplayRender.SetAlpha(0.0f);
    replaybuttonclicked = false;
    menubuttonclicked = false;
    bestscore = 0f;
 
	}


   
    
    public void replaybuttonclick()
    {
        MurderBotArm.position = new Vector3(258.53f, 53.58f, 0f);
        murderbot.transform.position = new Vector3(258.58f, 53.55f, 0f);
        murderbot.body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        murderbot.body.angularVelocity = 0.0f;
        replaybuttonclicked = true;
    }

    public void menubuttonclick()
    {
        menubuttonclicked = true;     
    }


	// Update is called once per frame
	void Update () {

        ReplayRender.SetAlpha(0.0f);

        if (murderbot.dead == true)
        {
            BestRender.SetAlpha(0.8f);
            EndScoreRender.SetAlpha(0.7f);
            

            #region setscores
            if (bestscore < Distance.greatestdistancefromstart)
            {
                bestscore = Distance.greatestdistancefromstart;
            }

            EndScore.text = Distance.greatestdistancefromstart.ToString();
            Best.text = bestscore.ToString();
            #endregion

            #region When Buttons Clicked
            if (replaybuttonclicked == true)
            {
                Distance.greatestdistancefromstart = 0f;
                murderbot.dead = false;
                replaybuttonclicked = false;
                GameOverScreen.SetActive(false);
            }


            #endregion

        }

	}
}
