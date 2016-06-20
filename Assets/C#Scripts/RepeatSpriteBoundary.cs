using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class RepeatSpriteBoundary : MonoBehaviour
{

    public Vector2 spriteSize;
    public Transform MurderBot;
    public GameObject OriginalObject;
    public GameObject GameOver;
    public GameOver GameOverInfo;
    private SpriteRenderer sprite;
    private GameObject newsprite;
    private GameObject destroysprite;
    private int i;
    private int numberofrepeats;
    private bool createsprite;
    private GameObject middlesprite;
    private bool replay;
  
    


    void CreateSprite()
    {
        newsprite = Instantiate(OriginalObject);
        newsprite.transform.position = transform.position + (new Vector3(spriteSize.x, 0) * i);
        newsprite.transform.parent = transform;
        newsprite.name = gameObject.name + i.ToString();
    }

    
    void CreateInitialObjects()
    {
    
        for (i = 0; i < 3; i++)
        {
            CreateSprite();
        }

    }
      
    
    void Start()
    {
        createsprite = false;
        sprite = OriginalObject.GetComponent<SpriteRenderer>();
        spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);
        newsprite = new GameObject();

        // Loop through and spit out repeated tiles

        CreateInitialObjects();
        replay = false;


        OriginalObject.transform.parent = transform;

    }



    void Update()
    {
                     
        middlesprite = GameObject.Find(gameObject.name + (i - 2).ToString());
        if (MurderBot.position.x > middlesprite.transform.position.x)
        {
            destroysprite = GameObject.Find(gameObject.name + (i - 3).ToString());
            Destroy(destroysprite);            
            CreateSprite();
            i++;
        }

        if (GameOverInfo.replaybuttonclicked == true)
        {

            for (int n = 0; n < 4; n++)
            {
                destroysprite = GameObject.Find(gameObject.name + (i - n).ToString());
                Destroy(destroysprite);
            }
           
            CreateInitialObjects();
        }

    }

}
