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
    
    public void changePlatform()
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


	// Update is called once per frame
	void Update () 
    {
	
	}
    void FixedUpdate()
    {
        for (int i = 0; i < segment.Length; i++)
        {
            //if segment had to be shifted
            if (segment[i].Move())
            {
                switch(Random.Range(0,7))
                {
                    case 0:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.Empty);
                    break;
                    case 1:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.A);
                    break;
                    case 2:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.V);
                    break;
                    case 3:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.BLine);
                    break;
                    case 4:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.ULine);
                    break;
                    case 5:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.TwoBottom);
                    break;
                    case 6:
                        segment[i].changePlatformPattern(EnumTypes.PlatformMapType.TwoTop);
                    break;

                    default:
                    segment[i].changePlatformPattern(EnumTypes.PlatformMapType.Empty);
                    break;

                }
            }
        }
    }
}
