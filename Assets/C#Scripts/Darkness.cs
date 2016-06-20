using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour
{

    public SpriteRenderer DarknessRender;
    public Transform Murderbot;
    public GameObject DarknessObject;
    private Color darknesstransparency;
    private float changeintime;
    private bool start;
    // Use this for initialization
    void Start()
    {

        darknesstransparency = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        DarknessRender.color = darknesstransparency;
        changeintime = 0.0f;
        start = true;
        DarknessObject.layer = LayerMask.NameToLayer("Default");
    }

    // Update is called once per frame
    void Update()
    {
        DarknessObject.transform.position = Murderbot.position;
        if (changeintime <= 2.0f)
        {
            changeintime += Time.deltaTime * 0.01f;
            if (start == false)
            {
                
                changeintime += Time.deltaTime * 0.01f;
                darknesstransparency = new Color(1.0f, 1.0f, 1.0f, changeintime * 0.18f);
                DarknessRender.color = darknesstransparency;
            }
        }
        else if (start == true)
        {
            start = false;
            changeintime = 0.0f;
        }
    }
}
