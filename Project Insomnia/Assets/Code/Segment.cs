using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour 
{
    Platform[] pForm;
    float segmentSpeed = 0.05f;
    // Use this for initialization
    void Awake()
    {
        pForm = this.gameObject.GetComponentsInChildren<Platform>();
    }
	void Start () 
    {
        
      
        /*
        for(int x = 0; x < 3; x++)
            for (int y = 0; y < 2; y++)
            {

                //pForm[x][y] = (Instantiate(Resources.Load("Objects/Platform", typeof(Platform)), new Vector3(0, 0, 1), new Quaternion()) as Platform);
            }
         */ 
       // InvokeRepeating("Moving", 0.05f,0.05f);	
	}

    // Update is called once per frame
    void Update() 
    {
        
	}
    
    public void triggerPlatform(int xCoord, int yCoord)
    {
        //Convert 2D to 1D coordinates
        int myPlatform = yCoord * (pForm.Length /2) + xCoord;
        //print("Triggering Platform: " + myPlatform);
        if (pForm[myPlatform].gameObject.renderer.enabled)
        {
            pForm[myPlatform].gameObject.renderer.enabled = false;
            pForm[myPlatform].gameObject.collider2D.enabled = false;

        }
        else
        {
            pForm[myPlatform].gameObject.renderer.enabled = true;
            pForm[myPlatform].gameObject.collider2D.enabled = true;
        }
    }

    public void triggerPlatform(int xCoord, int yCoord, bool enabled)
    {
        //Convert 2D to 1D coordinates
        int myPlatform = yCoord * (pForm.Length / 2) + xCoord;
        //print("Triggering Platform: " + myPlatform);
        if (enabled)
        {
            pForm[myPlatform].gameObject.renderer.enabled = true;
            pForm[myPlatform].gameObject.collider2D.enabled = true;

        }
        else
        {
            pForm[myPlatform].gameObject.renderer.enabled = false;
            pForm[myPlatform].gameObject.collider2D.enabled = false;
        }
    }

    void FixedUpdate()
    {
        
    }

    public void updateSpeed(float newSpeed)
    {
        segmentSpeed = newSpeed;
    }
    //return if shifted to front
    public bool Move()
    {
       
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - segmentSpeed, 0, 0);
        if (this.gameObject.transform.position.x < -30)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 90f, 0, 0);
            return true;
        }
        return false;
    }

    public void changePlatformPattern(EnumTypes.PlatformMapType myPlatformSetup)
    {
        switch (myPlatformSetup)
        {
            case EnumTypes.PlatformMapType.Empty:

                triggerPlatform(0, 0, false);
                triggerPlatform(1, 0, false);
                triggerPlatform(2, 0, false);
                triggerPlatform(0, 1, false);
                triggerPlatform(1, 1, false);
                triggerPlatform(2, 1, false);
                break;
            case EnumTypes.PlatformMapType.A:
                //Top
                triggerPlatform(0, 0, false);
                triggerPlatform(1, 0, true);
                triggerPlatform(2, 0, false);
                //Bottom
                triggerPlatform(0, 1, true);
                triggerPlatform(1, 1, false);
                triggerPlatform(2, 1, true);
                break;
            case EnumTypes.PlatformMapType.BLine:
                //Top
                triggerPlatform(0, 0, true);
                triggerPlatform(1, 0, true);
                triggerPlatform(2, 0, true);
                //Bottom
                triggerPlatform(0, 1, false);
                triggerPlatform(1, 1, false);
                triggerPlatform(2, 1, false );
                break;
            case EnumTypes.PlatformMapType.ULine:
                //Top
                triggerPlatform(0, 0, false);
                triggerPlatform(1, 0, false);
                triggerPlatform(2, 0, false);
                //Bottom
                triggerPlatform(0, 1, true);
                triggerPlatform(1, 1, true);
                triggerPlatform(2, 1, true);
                break;
            case EnumTypes.PlatformMapType.V:
                //Top
                triggerPlatform(0, 0, true);
                triggerPlatform(1, 0, false);
                triggerPlatform(2, 0, true);
                //Bottom
                triggerPlatform(0, 1, false);
                triggerPlatform(1, 1, true);
                triggerPlatform(2, 1, false);
                break;
            case EnumTypes.PlatformMapType.TwoBottom:
                //Top
                triggerPlatform(0, 0, false);
                triggerPlatform(1, 0, false);
                triggerPlatform(2, 0, false);
                //Bottom
                triggerPlatform(0, 1, true);
                triggerPlatform(1, 1, false);
                triggerPlatform(2, 1, true);
                break;
            case EnumTypes.PlatformMapType.TwoTop:
                //Top
                triggerPlatform(0, 0, true);
                triggerPlatform(1, 0, false);
                triggerPlatform(2, 0, true);
                //Bottom
                triggerPlatform(0, 1, false);
                triggerPlatform(1, 1, false);
                triggerPlatform(2, 1, false);
                break;

            default:
                triggerPlatform(0, 0, false);
                triggerPlatform(1, 0, false);
                triggerPlatform(2, 0, false);
                triggerPlatform(0, 1, false);
                triggerPlatform(1, 1, false);
                triggerPlatform(2, 1, false);
                break;
        }
    }
}
