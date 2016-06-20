using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

    public GameState GameStateScript;
    public GameOver GameOverScript;
    public GameObject RedPlatform;
    public GameObject GreenPlatform;
    public GameObject GreyPlatform;
    public Transform EndPlatforms;
    public GameObject OldPlatorm;
    private int levelselector;
    private Vector3 endplatformsinitialposition;
    private Vector3 oldplatforminitialposition;
    private bool selectlevel;
	// Use this for initialization
	void Start () {
        levelselector = Random.Range(0, 5);
        endplatformsinitialposition = EndPlatforms.localPosition;
        oldplatforminitialposition = OldPlatorm.transform.localPosition;
        SetLevel(levelselector);
        selectlevel = true;
        
	}
	
    public void SetLevel(int levelselector)
    {
      //Red Platform  
        if (levelselector < 2)
        {
            
            GreenPlatform.SetActive(false);
            RedPlatform.SetActive(true);
            GreyPlatform.SetActive(true);
            EndPlatforms.localPosition = endplatformsinitialposition + new Vector3(2.0f, 0.0f, 0.0f);
            OldPlatorm.SetActive(false);
            OldPlatorm.transform.localPosition = oldplatforminitialposition;
            

        }
       //Green Platform
        else if (levelselector < 4)
        {
            GreyPlatform.SetActive(false);
            RedPlatform.SetActive(false);
            GreenPlatform.SetActive(true);
            OldPlatorm.SetActive(true);
            EndPlatforms.localPosition = endplatformsinitialposition + new Vector3(3.0f, 0.0f, 0.0f);
            OldPlatorm.transform.localPosition = oldplatforminitialposition;

        }
        //Grey Platform
        else
        {
            RedPlatform.SetActive(false);
            GreenPlatform.SetActive(false);
            GreyPlatform.SetActive(true);
            OldPlatorm.SetActive(true);
            OldPlatorm.transform.localPosition = oldplatforminitialposition + new Vector3(0.0f, -2.7f, 0.0f);
            EndPlatforms.localPosition = endplatformsinitialposition + new Vector3(3.0f, 0.0f, 0.0f);
        }

    }

    void GetNewLevel()
    {
        levelselector = Random.Range(0, 5);
        SetLevel(levelselector);

    }


	// Update is called once per frame
	void Update () {
       
        if (GameOverScript.replaybuttonclicked == true)
        {
            selectlevel = true;
        }

        if (GameStateScript.regeneratenewlevels == true)
        {
            selectlevel = true;
            GameStateScript.regeneratenewlevels = false;
        }

        if (selectlevel == true)
        {
            GetNewLevel();
            selectlevel = false;
        }

	}
}
