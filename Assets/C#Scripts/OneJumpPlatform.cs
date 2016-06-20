using UnityEngine;
using System.Collections;

public class OneJumpPlatform : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("MurderBot"))
        {
            this.gameObject.SetActive(false);
        }


    }


	// Update is called once per frame
	void Update () {

   



	}
}
