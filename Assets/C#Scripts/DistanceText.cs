using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceText : MonoBehaviour
{

    public Text TextBox;
    public Transform murderbot;
    public RectTransform textboxpos;
    public GameObject playplay;
    public Play Playtouch;
    public CanvasRenderer textcanvas;
    public float greatestdistancefromstart;
    private int textsize;
    private float textsizesize;
    private float distancefromstart;

    private Vector3 startvector;
    private Vector3 currentvector;


    // Use this for initialization
    void Start()
    {
        textcanvas.SetAlpha(0.6f);
        Playtouch = (Play)playplay.GetComponent(typeof(Play));
        TextBox.text = "";
        startvector = murderbot.position;
        distancefromstart = 0;
        greatestdistancefromstart = 0;
        textsizesize = 10.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
       
       

        if (Playtouch.playtouched == true)
        {
            currentvector = murderbot.position;
            distancefromstart = Mathf.RoundToInt(currentvector.x - startvector.x);

            if (distancefromstart > greatestdistancefromstart)
            {
                greatestdistancefromstart = distancefromstart;
            }

            TextBox.text = greatestdistancefromstart.ToString() + "m";

            textsize =  Mathf.FloorToInt(greatestdistancefromstart / textsizesize);

            if (textsize == 1)
            {
                textboxpos.position += new Vector3(-30.0f, 0);
                textsizesize = textsizesize * 10.0f;
            }


        }

        else 
        {
        TextBox.text = "";
       
        }


    }
}

