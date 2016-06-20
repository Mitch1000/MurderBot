using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour {

	// Use this for initialization
    public GameObject RedPlatform2;
    public GameObject RedPlatform3;
    public GameObject RedPlatform4;
    public GameState GameStateScript;
    public GameOver GameOverScript;
    private bool selectlevel;
	void Start () {
	
	}

    void SetLevel2()
    {

        RedPlatform2.SetActive(true);
        RedPlatform3.SetActive(true);
        RedPlatform4.SetActive(true);
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
            SetLevel2();
            selectlevel = false;
        }


	}
}
