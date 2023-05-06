using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private InputAction horizontalMovement;
    [SerializeField] private LayerMask jumpableGround;

    private bool playerJumped;
    private Vector2 moveDirection;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource jumpSFX;

    private PauseLogic pauseLogic;

    private enum MovementState { idle, running, jumping, falling }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        pauseLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<PauseLogic>();
    }
    private void OnEnable()
    {
        horizontalMovement.Enable();
    }

    private void OnDisable()
    {
        horizontalMovement.Disable();
    }

    private void Update()
    {
        if (!pauseLogic.isPaused)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame) playerJumped = true;
            moveDirection = horizontalMovement.ReadValue<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        if (rb2d.bodyType != RigidbodyType2D.Static)
        {
            rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, rb2d.velocity.y);

            if (playerJumped && IsGrounded())
            {
                jumpSFX.Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                playerJumped = false;
            }
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (moveDirection.x > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (moveDirection.x < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb2d.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb2d.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
