using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private new Collider2D collider;

    public float moveSpeed = 5f;
    public float jumpStrength = 5f;
    public bool isGrounded;
    public LayerMask groundLayer;

    public GameManager theGameManager;

    private Animator myAnimator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);

        isGrounded = Physics2D.IsTouchingLayers(collider, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpStrength);
        }

        myAnimator.SetFloat("Speed", rigidBody.velocity.x);
        myAnimator.SetBool("Grounded", isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "KillObject")
        {
            theGameManager.Restart();
        }
    }
}