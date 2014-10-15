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

    void FixedUpdate()
    {
        Moving();
    }

    public void updateSpeed(float newSpeed)
    {
        segmentSpeed = newSpeed;
    }

    void Moving()
    {
       
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - segmentSpeed, 0, 0);
        if (this.gameObject.transform.position.x < -30)
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 90f, 0, 0);
    }
}
