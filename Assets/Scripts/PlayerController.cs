using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed;
    public float JumpForce;
    public bool grounded;
    public LayerMask groundLayer;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;

	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
    }
	
	void Update () {
        grounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

        playerRigidBody.velocity = new Vector2(MoveSpeed, playerRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, JumpForce);
        }

        playerAnimator.SetBool("Grounded", grounded);
        playerAnimator.SetFloat("Speed", playerRigidBody.velocity.x);
	}
}
