using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
    public GameObject MurderBot;
    public murderbotcontroller MurderbotClass;
    public GameObject GameScreensCanvas;
    public GameObject GameOverScreen;
    public GameObject HomeScreen;
    public GameObject MurderBotArm;
    public Play Play;
    public GameObject LevelHolder;
    public GameObject[] Levels;
    public GameObject EndofLevel;
    public bool GameOverScreenActive;
    public bool regeneratenewlevels;
    private int levelsunlocked;
    private int level;
    private bool start;
    private int previouslevel;
    private int nextlevel;
    private bool levelswitch;
    private int i;
    public int totalcreatedlevels;
    private bool forcenextlevel;
    private LevelUnlocked ShowLevel;
    private LevelUnlocked ShowLevelStars;
    

	// Use this for initialization
	void Start () 
    {
        Levels = new GameObject[LevelHolder.transform.childCount];
        i = 0;
        foreach (object element in Levels)
        {
            Levels[i] = GameObject.Find("/Levels/Level" + (i + 1).ToString());
            Levels[i].SetActive(false);
            i++;
        }
        levelsunlocked = 0;
        level = 0;
        nextlevel = 0;
        levelswitch = false;
        GameOverScreenActive = true;
        start = true;
        previouslevel = 100;
        totalcreatedlevels = 2;
        forcenextlevel = false;
        ShowLevel = GameObject.Find("LevelUnlocked").GetComponent<LevelUnlocked>();
        ShowLevelStars = GameObject.Find("LevelUnlockedStars").GetComponent<LevelUnlocked>();
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Play.playtouched == true)
        {
            if (MurderbotClass.initialized == true)
            {
                MurderbotClass.dead = false;
                MurderbotClass.initialized = false;
                MurderbotClass.body.velocity = Vector3.zero;
                MurderbotClass.body.angularVelocity = 0.0f;

            }
        }
        
        if (MurderbotClass.dead == true)
        {
  
            if (Play.playtouched == false)
            {
                GameOverScreen.SetActive(false);
            }
            else
            {
                GameOverScreen.SetActive(true);
                GameOverScreenActive = true;
            }          
            
            MurderBot.SetActive(false);
            MurderBotArm.SetActive(false);

        }

        else
        {

            if (GameOverScreenActive == true)
            {
                if (previouslevel < 99) { Levels[previouslevel].SetActive(false); }
                Levels[level].SetActive(false);
                Levels[nextlevel].SetActive(false);
                
                if (levelsunlocked > 2)
                {
                    level = Random.Range(0, levelsunlocked);
                }
                else
                {
                    level = 0;
                }

                Levels[level].transform.position = new Vector3(MurderBot.transform.position.x, Levels[level].transform.position.y);
                Levels[level].SetActive(true);
                if (levelsunlocked > 0) { nextlevel = level; }
                MurderBotArm.SetActive(true);
                MurderBot.SetActive(true);
                GameOverScreenActive = false;

            }
         
        }

        //If MurderBot Passes A level that has not been unlocked increase the number of levels that have been unlocked and show "Level Unlocked"
        if (MurderBot.transform.position.x > Levels[levelsunlocked + 1].transform.position.x - 2.0f && levelsunlocked + 1 <= totalcreatedlevels)
        {
            levelsunlocked++;
            ShowLevel.UnlockLevel();
        }
        //If Murderbut is on the highest level that has been unlocked ensure the next level will be a new level(unless there is no new level created)
        if (MurderBot.transform.position.x > Levels[levelsunlocked].transform.position.x && levelsunlocked + 1 <= totalcreatedlevels)
        {
            forcenextlevel = true;
        }


        //Debug.Log("levelswitch" + levelswitch);
        //Debug.Log("Murderbot Position X: " + MurderBot.transform.position.x.ToString());
        //Debug.Log("Next Level Position X: " + Levels[nextlevel].transform.position.x.ToString());
        //Debug.Log("Levels Unlocked" + levelsunlocked.ToString());

        //If MurderBot is approaching the next level set the next level to be active
        //Debug.DrawRay(Levels[nextlevel].transform.position = new Vector3(-20.0f, 0.0f, 0.0f), Levels[nextlevel].transform.TransformDirection(Vector3.up), Color.red, 100.0f);    
        if (MurderBot.transform.position.x > Levels[nextlevel].transform.position.x - 10.0f && levelswitch == false)
        {
            Levels[nextlevel].SetActive(true);
            levelswitch = true;

        }

        //If murder bot has reached the next level set the next level to current level and the previous level to the level that the  bot has just left
        if (MurderBot.transform.position.x > Levels[nextlevel].transform.position.x)
        {
            previouslevel = level;
            level = nextlevel;
            regeneratenewlevels = true;
        }

        //Find a random next level 
        if (forcenextlevel == false)
        {
            while (nextlevel == level || nextlevel == previouslevel)
            {
                nextlevel = Random.Range(0, levelsunlocked + 1);
            }
        }
        // set next level to a new level
        else
        {
            nextlevel = levelsunlocked + 1;
            forcenextlevel = false;
        }

        // move the next level to the end of the current level
        EndofLevel = GameObject.Find("/Levels/Level" + (level + 1).ToString() + "/EndofLevel");
        Levels[nextlevel].transform.position = new Vector3(EndofLevel.transform.position.x + 6.0f, Levels[nextlevel].transform.position.y);

        //deactivate the previous level if the murderbot has reached a certain point in the current level
        if (MurderBot.transform.position.x > Levels[level].transform.position.x + 12.0f && levelswitch == true)
        {
            if (previouslevel < 99 && previouslevel != level) { Levels[previouslevel].SetActive(false); }

            levelswitch = false;

        }

        //Debug.Log("Previous Level: " + previouslevel);
        //Debug.Log("Next Level: " + nextlevel);
        //Debug.Log("Level: " + level);
        //Debug.Log("Levels Unlocked: " + levelsunlocked);


	}
}
