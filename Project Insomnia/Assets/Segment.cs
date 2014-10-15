using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour 
{
    private float startPosition;
	// Use this for initialization
	void Start () 
    {
        startPosition = this.gameObject.transform.position.x;
        InvokeRepeating("Moving", 0.07f,0.07f);	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void Moving()
    {
        print("I was called");
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 0.2f, 0, 0);
        if (this.gameObject.transform.position.x < -30)
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 90f, 0, 0);
    }
}
