using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUnlocked : MonoBehaviour {

    public RectTransform LevelUnlockedTransform;
    public CanvasRenderer LevelUnlockedSprite;
    private float changeintime;
    private Vector3 initialposition;
    private bool complete;

	// Use this for initialization
	void Start () 
    {

        changeintime = 0.0f;
        initialposition = LevelUnlockedTransform.anchoredPosition;
        complete = true;
        LevelUnlockedSprite.SetAlpha(0.0f);

	}

    void UnlockLevelFunction()
    {
        if (complete == false)
        {
            if (changeintime < 1.0f)
            {

                changeintime += Time.deltaTime;
                LevelUnlockedTransform.anchoredPosition = initialposition + new Vector3(0.0f, changeintime * 30.0f);
                LevelUnlockedSprite.SetAlpha(1.0f - changeintime);
                complete = false;
            }

            if (changeintime > 1.0f)
            {               
                LevelUnlockedSprite.SetAlpha(0.0f);
                changeintime = 0.0f;
                complete = true;
            }
        }
    }


   public void UnlockLevel()
    {
        complete = false;
    }

	// Update is called once per frame
	void Update () {
 

        if (complete == false)
        {
            UnlockLevelFunction();
        }


	}
}
