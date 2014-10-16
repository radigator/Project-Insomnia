using UnityEngine;
using System.Collections;
//Camera and Main Class
public class Main : MonoBehaviour 
{
    DifficultyMonitor dMan;
    //Database Coordinates 

    //Character 6yrs old
    Character Noah;

    //Monster Coordinates
    //Left screen x = -Value

    //Platform Coordinates
    SegmentManager segMan;
    
    //Obstacle Coordinates

    //Background
    private Background2D backGround;
    //Level Variables to reference
    public EnumTypes.CloudState CloudCoverage;
    public EnumTypes.DayState DaySegment;
    public EnumTypes.BackgroundSelection bgSelection;

    public float relativeBackGroundLocation = 0.0f;
	// Use this for initialization
    void Awake()
    {
        //Load code from Code Library
        Noah = GameObject.FindObjectOfType<Character>();
        dMan = this.gameObject.AddComponent<DifficultyMonitor>();       
        segMan = GameObject.FindObjectOfType<SegmentManager>();
        dMan.setJumpForce(Noah.jumpForce);    
    }

    void Start () 
    {
        backGround = GameObject.Find("Background").GetComponent<Background2D>();
        backGround.setupClouds(CloudCoverage);
        backGround.setupBackground(bgSelection);
        backGround.SetDaySelection(DaySegment);
        //Top Row y = 0
        //Bottom row y = 1;

        segMan.triggerPlatform(0, 0, 0);
        segMan.triggerPlatform(0, 1, 0);
        segMan.triggerPlatform(0, 2, 0);
        //segMan.triggerPlatform(0, 0, 1);
        //segMan.triggerPlatform(0, 1, 1);
        //segMan.triggerPlatform(0, 2, 1);
        segMan.triggerPlatform(1, 0, 0);
        segMan.triggerPlatform(1, 1, 0);
        segMan.triggerPlatform(1, 2, 0);
        //segMan.triggerPlatform(1, 0, 1);
        //segMan.triggerPlatform(1, 1, 1);
        //segMan.triggerPlatform(1, 2, 1);
        segMan.triggerPlatform(2, 0, 0);
        segMan.triggerPlatform(2, 1, 0);
        segMan.triggerPlatform(2, 2, 0);
        //segMan.triggerPlatform(2, 0, 1);
        //segMan.triggerPlatform(2, 1, 1);
        //segMan.triggerPlatform(2, 2, 1);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    void FixedUpdate()
    {
        relativeBackGroundLocation = segMan.updateSegmentSpeed(dMan.getSegmentSpeed());
        Noah.rigidbody2D.mass = dMan.getCharacterMass();
        backGround.BackgroundUpdate(relativeBackGroundLocation);
        //Noah.jumpForce = dMan.getCharacterJumpForce();
    }
}
