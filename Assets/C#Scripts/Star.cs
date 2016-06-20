using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Star : MonoBehaviour {
    public GameObject StarGameObject;
    public Transform StarParent;
    public Transform Target;
    public float xrange;
    public float yrange;
    private float destroytime;
    public int NumberofCreatedStars;
    private LevelUnlocked LevelUnlocked;
    private float startime;
    private int numberofstars;
    private int destroyedstars;
    private GameObject destroystar;
    private GameObject newstar;



	// Use this for initialization
	void Start () {
        numberofstars = 0;
        startime = 0.0f;
        destroytime = 0.1f;
        destroyedstars = 0;
        StarGameObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        LevelUnlocked = StarGameObject.GetComponent<LevelUnlocked>();
        // Create the First Set of Stars
        for(int i = 0; i < NumberofCreatedStars; i++)
        {
            newstar = Instantiate(StarGameObject);
            newstar.transform.SetParent(StarParent);
            newstar.transform.localPosition = Target.localPosition + new Vector3(Random.Range(0.0f, xrange), Random.Range(0.0f, yrange), 0);
            newstar.transform.localScale = new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.2f, 0.6f), 0);
            newstar.name = "Star" + (numberofstars).ToString();
            numberofstars++;
        }
	}
	
	// Update is called once per frame
	void Update () {

            StarGameObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            startime += Time.deltaTime;
            if (startime < 0.3f)
            {              

                if (startime > destroytime)
                {                                     
                    destroystar = GameObject.Find("Star" + destroyedstars);
                    Destroy(destroystar);
                    destroytime += Random.Range(0.01f,0.05f);
                    destroyedstars++;
                    numberofstars++;

                    newstar = Instantiate(StarGameObject);
                    newstar.transform.SetParent(StarParent);
                    newstar.transform.localPosition = Target.localPosition + new Vector3(Random.Range(0.0f, xrange), Random.Range(0.0f, yrange), 0);
                    newstar.transform.localScale = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f), 0);
                    newstar.name = "Star" + (numberofstars).ToString();
                }             

            }

            else
            {
                startime = 0.0f;
                destroytime = 0.02f;
            }

	}
}
