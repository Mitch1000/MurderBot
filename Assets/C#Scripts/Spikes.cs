using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    public GameObject Spike;
    public GameObject Wood;
    public Collider2D WoodCollider;
    public CreateWood WoodScript;
    public float SpikesMinDistanceApart;
    public float SpikesMaxDistanceApart;
    public int numberofspikes;
    private GameObject newspike;
    private int numberofspikescreated;
    private float spikedistance;
    private float spiketotaldistance;

    
    
	// Use this for initialization
	void Start () 
    {
               
        numberofspikescreated = 1;
        spiketotaldistance = 0.0f;

        for (int i = 0; i <= numberofspikes; i++)
        {
            spikedistance = Random.RandomRange(SpikesMinDistanceApart, SpikesMaxDistanceApart);
            spiketotaldistance += spikedistance;


            if (numberofspikescreated < numberofspikes && WoodCollider.bounds.size.x > spiketotaldistance + SpikesMaxDistanceApart)
            {
                newspike = Instantiate(Spike);
                newspike.transform.parent = gameObject.transform;
                newspike.transform.localPosition = Spike.transform.localPosition + new Vector3(spiketotaldistance, 0.0f, 0.0f);
                newspike.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                numberofspikescreated++;
            }
        }
	}
	


}
