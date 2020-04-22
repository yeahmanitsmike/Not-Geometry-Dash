using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
   // private new Collider2D collider;

    //Player movement vars
    public float moveSpeed = 5f;
    public float speedMulitplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float moveSpeedStore;
    private float speedMilestoneCountStore;

    //Player jump vars
    public float jumpStrength = 5f;
    public float jumpTime;
    private float jumpTimeCounter;

    //Ground vars
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public GameManager theGameManager;

    private Animator myAnimator;

    public AudioSource backgroundMusic;
    public AudioSource jumpSound;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
       // collider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    private void Update()
    { 
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);

        //isGrounded = Physics2D.IsTouchingLayers(collider, groundLayer);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMulitplier;

            moveSpeed = moveSpeed * speedMulitplier;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpStrength);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpStrength);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCounter = 0;
        }

        if (isGrounded)
        {
            jumpTimeCounter = jumpTime;
        }

        myAnimator.SetFloat("Speed", rigidBody.velocity.x);
        myAnimator.SetBool("Grounded", isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "KillObject")
        {
            theGameManager.Restart();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            backgroundMusic.Stop();
            
        }
    }
}