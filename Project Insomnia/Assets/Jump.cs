using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour 
{
    bool bInAir = false;
    public float jumpForce = 100;
	void Awake()
    {

    }
    // Use this for initialization
    void Start () 
    {

        ///Invoke()
	}
	
	// Update is called once per frame
	void Update () 
    {
        JumpControl();
	}

    void FixedUpdate()
    {
        
       
        
    }

    void JumpControl()
    {
        if (Input.GetAxis("Jump") > 0 && !bInAir)
        {
            this.gameObject.rigidbody2D.AddForce(new Vector2(0, jumpForce));
            bInAir = true;
        }
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ground"))
            bInAir = false;
    }
    /*
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
            bInAir = false;
    } 
     * */
}
