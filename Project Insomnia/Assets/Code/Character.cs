using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
    bool bInAir = true;
    bool bCollidingPlatform = false;
    public float jumpForce = 200f;
    private float jumpForceFWD = 0.5f;
    private float thersholdForceTime = 0.0f;
    private bool bAllowedToJump = false;
    Vector2 Size;
	void Awake()
    {

    }
    // Use this for initialization
    void Start () 
    {
        Size = this.gameObject.GetComponent<BoxCollider2D>().size;
        //InvokeRepeating("ButtonBreaker", 0.2f, 0.2f);
    }
    void ButtonBreaker()
    {
        bAllowedToJump = true;
    }
	// Update is called once per frame
	void Update () 
    {
         
	}

    void FixedUpdate()
    {
        JumpControl();  
        stabilzeCharacter();
    }

    public bool testGround()
    {
        Vector2 fwd = transform.TransformDirection(-Vector2.up);
        float length = 0.008f;
        Debug.DrawRay(new Vector2(this.gameObject.transform.position.x - 0.5f, this.gameObject.transform.position.y - (Size.y) - 0.1f), new Vector2(fwd.x,length), Color.red, 0.5f);
        
        RaycastHit2D groundHit = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x - 0.5f, this.gameObject.transform.position.y - (Size.y) - 0.1f), fwd, length);
        
        if (groundHit)
        {
            thersholdForceTime = 0;
            //print(groundHit.collider.gameObject.GetInstanceID() + ", " + this.gameObject.GetInstanceID());
            
            return true;
        }
        if (thersholdForceTime < 0.3f)
        {
            print(thersholdForceTime);
            thersholdForceTime += 0.1f;
            return true;
        }
        //bAllowedToJump = true;
        return false;
    }

    public bool testClimb()
    {
        Vector2 fwd = transform.TransformDirection(-Vector2.up);
        RaycastHit2D ceilingHit = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (Size.y / 2) + 0.002f), fwd, 0.038f);
        if (ceilingHit)
            return true;
        
        return false;
    }

    void stabilzeCharacter()
    {
        this.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    void JumpControl()
    {
        if(Input.GetAxis("Jump") == 1 && testGround())
            this.gameObject.rigidbody2D.AddForce(new Vector2(jumpForceFWD, jumpForce));
        /*
        if (testGround() && Input.GetAxis("Jump") == 1 && bAllowedToJump)
        {
            if (thersholdForceTime < 0.5f)
            {
                print(thersholdForceTime);
                this.gameObject.rigidbody2D.AddForce(new Vector2(jumpForceFWD, jumpForce));
                thersholdForceTime += 0.1f;
            }
            else
            {
                bAllowedToJump = false;
                thersholdForceTime = 0;
            }
            //bInAir = true;
            //bAllowedToJump = false;
            //print("jump");
        }
      */
        
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("Ground") || collision.gameObject.name.Equals("Platform"))
        {
            bAllowedToJump = true;
            //bInAir = false;
            //bCollidingPlatform = true;   
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ground") || collision.gameObject.name.Equals("Platform"))
        {
            bAllowedToJump = true;
           //bCollidingPlatform = true;

        }
            //bInAir = false;
           // JumpControl(); 
        
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("Ground") || collision.gameObject.name.Equals("Platform"))
        {
            bAllowedToJump = false;
            //bCollidingPlatform = false;
        }
    } 
     */
}
