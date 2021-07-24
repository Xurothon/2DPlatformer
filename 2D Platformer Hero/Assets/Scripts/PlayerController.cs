using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove;
    public float jumpSpeed;
    public Rigidbody2D playerRigidbody;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public Vector3 respawnPosition;
    public LevelManager theLevelManager;
    public GameObject stopmBox;
    public float knokbackForce;
    public float knockbackLength;
    public float invinicibilityLength;
    public float onPlatformSpeedModifier;
    private bool _isAttack;
    private Animator _animator;
    private float invinicibilityCounter;
    private bool _isOnPlatform;
    private float knockbackCounter;
    private float activeMoveSpeed;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        respawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
        activeMoveSpeed = moveSpeed;
        canMove = true;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (knockbackCounter <= 0 && canMove)
        {
            if (_isOnPlatform)
            {
                activeMoveSpeed = moveSpeed * onPlatformSpeedModifier;
            }
            else
            {
                activeMoveSpeed = moveSpeed;
            }

            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                playerRigidbody.velocity = new Vector3(activeMoveSpeed, playerRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                playerRigidbody.velocity = new Vector3(-activeMoveSpeed, playerRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                playerRigidbody.velocity = new Vector3(0f, playerRigidbody.velocity.y, 0f);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, jumpSpeed, 0f);
            }
            if (Input.GetButtonDown("Fire3"))
            {
                _isAttack = true;
            }
            else { _isAttack = false; }
            _animator.SetBool("Attack", _isAttack);
            theLevelManager.invincible = false;
        }
        if (knockbackCounter > 0)
        {
            knockbackCounter -= Time.deltaTime;
            if (transform.localScale.x > 0)
            {
                playerRigidbody.velocity = new Vector3(-knokbackForce, knokbackForce, 0f);
            }
            else
            {
                playerRigidbody.velocity = new Vector3(knokbackForce, knokbackForce, 0f);
            }
        }
        if (invinicibilityCounter > 0)
        {
            invinicibilityCounter -= Time.deltaTime;
        }
        else
        {
            theLevelManager.invincible = false;
        }
        _animator.SetFloat("Speed", Mathf.Abs(playerRigidbody.velocity.x));
        _animator.SetBool("Grounded", isGrounded);
        if (playerRigidbody.velocity.y < 0)
        {
            stopmBox.SetActive(true);
        }
        else
        {
            stopmBox.SetActive(false);
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        invinicibilityCounter = invinicibilityLength;
        theLevelManager.invincible = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            theLevelManager.Respawn();
        }
        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            _isOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            _isOnPlatform = false;
        }
    }
}