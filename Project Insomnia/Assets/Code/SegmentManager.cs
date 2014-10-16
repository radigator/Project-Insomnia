using UnityEngine;
using System.Collections;

public class SegmentManager : MonoBehaviour 
{
    //SegmentArray
    Segment[] segment;
    float segmentSpeed;
    float relativePosition = 0.0f;
	// Use this for initialization
    void Awake()
    {
        segment = GameObject.FindObjectsOfType<Segment>();
    }

	void Start () 
    {
     
	}

    public float updateSegmentSpeed(float newSpeed)
    {
        segmentSpeed = newSpeed;
        for (int i = 0; i < segment.Length; i++)
            segment[i].updateSpeed(newSpeed);

       
        relativePosition += segmentSpeed;

         return relativePosition;
    }
    
    public void triggerPlatform(int pCoord,int xCoord,int yCoord)
    {
        segment[pCoord].triggerPlatform(xCoord, yCoord);
    }
    
    public void deleteAllPlatforms()
    {

    }


	// Update is called once per frame
	void Update () 
    {
	
	}
}
