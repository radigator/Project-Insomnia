using UnityEngine;
using System.Collections;

public class DifficultyMonitor : MonoBehaviour 
{
    float segmentSpeed = 0.1f;
    float characterMass = 1.0f;
    float characterJumpForce = 200f;
	// Use this for initialization
	void Start () 
    {
        print("DifficultyMonitor: Started");
        InvokeRepeating("Tick", 10.0f, 10.0f);
	}

    private void Tick()
    {   
        if (segmentSpeed < 0.18f)
        {
            segmentSpeed *= 1.1f;
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
