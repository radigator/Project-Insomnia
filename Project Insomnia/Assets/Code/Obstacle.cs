using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D myCollision)	
	{
		if (myCollision.gameObject.name.Equals("Noah")) 
		{
			myCollision.gameObject.rigidbody2D.AddForce(new Vector2(-25f, 0));
		}
	}
}
