using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
    bool bInAir = true;
    bool bCollidingPlatform = false;
    public float jumpForce = 200f;
    private float jumpForceFWD = 0.5f;
    private float thersholdForceTime = 0.0f;

    Vector2 Size;
	
    void Awake()
    {

    }

    // Use this for initialization
    void Start () 
    {
        Size = this.gameObject.GetComponent<BoxCollider2D>().size;
       
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
        //Debug.DrawRay(new Vector2(this.gameObject.transform.position.x - 0.05f, this.gameObject.transform.position.y - (Size.y) - 0.53f), new Vector2(fwd.x,length), Color.red, 5.5f);
        
        RaycastHit2D groundHit = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x - 0.05f, this.gameObject.transform.position.y - (Size.y) - 0.53f), fwd, length);
        
        //if(groundHit.collider != null)
        //print(groundHit.collider.gameObject.name);

        if (groundHit)
        {
            thersholdForceTime = 0;
            
            return true;
        }
        
        if (thersholdForceTime < 0.6f)
        {
            //print(thersholdForceTime);
            thersholdForceTime += 0.1f;
            return true;
        }

        return false;
    }

    public bool testClimb()
    {
        Vector2 fwd = transform.TransformDirection(-Vector2.up);
        RaycastHit2D ceilingHit = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x - 0.55f, this.gameObject.transform.position.y + (Size.y / 2) + 0.002f), fwd, 0.038f);
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
        if (Input.GetAxis("Jump") == 0)
            thersholdForceTime = 0.6f;
        
    }

}
