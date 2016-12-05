using UnityEngine;

public class PlayerController : MonoBehaviour {

    public LayerMask GroundLayer;
    public Transform GroundCheck;

    public float GroundCheckRadious;
    public float SpeedMultiplier;
    public float SpeedIncreaseMilestone;
    public float MoveSpeed;
    public float JumpForce;    
    public float JumpTime;

    public bool Grounded;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;

    private float jumpTimeCounter;
    private float speedMilestoneCount;

	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        jumpTimeCounter = JumpTime;
        speedMilestoneCount = SpeedIncreaseMilestone;
    }
	
	void Update () {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadious, GroundLayer);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += SpeedIncreaseMilestone;
            MoveSpeed = MoveSpeed * SpeedMultiplier;
            SpeedIncreaseMilestone = SpeedIncreaseMilestone * SpeedMultiplier;          
        }

        playerRigidBody.velocity = new Vector2(MoveSpeed, playerRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, JumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && !Grounded)
        {
            if(jumpTimeCounter > 0)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, JumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
                jumpTimeCounter = 0;
        }

        if (Grounded)
        {
            jumpTimeCounter = JumpTime;
        }

        playerAnimator.SetBool("Grounded", Grounded);
        playerAnimator.SetFloat("Speed", playerRigidBody.velocity.x);
	}
}
