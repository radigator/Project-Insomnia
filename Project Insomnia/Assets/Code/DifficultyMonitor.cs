using UnityEngine;
using System.Collections;

public class DifficultyMonitor : MonoBehaviour 
{
    float segmentSpeed = 0.05f;
    float characterMass = 1.0f;
    float characterJumpForce = 200f;
	// Use this for initialization
	void Start () 
    {
        print("DifficultyMonitor: Started");
        InvokeRepeating("Tick", 1.0f, 1.0f);
	}

    private void Tick()
    {   
        if (segmentSpeed < 0.15f)
        {
            segmentSpeed *= 1.1f;
            //Lower jump force
           // if(segmentSpeed > 0.1)
             //   characterJumpForce *= 0.96f;
           //characterMass *= 1.025f;
        }
    }

    public float getSegmentSpeed()
    {
        return segmentSpeed;
    }

    public void setJumpForce(float initialJump)
    {
        characterJumpForce = initialJump;
    }

    public float getCharacterMass()
    {
        return characterMass;
    }
    public float getCharacterJumpForce()
    {
        return characterJumpForce;
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
