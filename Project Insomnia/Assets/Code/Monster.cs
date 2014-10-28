using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

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
			Application.LoadLevel(0);
		}
	}
}
