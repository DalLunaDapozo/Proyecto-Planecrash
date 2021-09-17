using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    [SerializeField] private float movementSpeed;


    private float axisValue;
    
    private Rigidbody2D rigidBody = null;
    private SpriteRenderer spriteRenderer = null;
    private Animator animator = null;

    [SerializeField] private AudioSource audioSource;
    
    public bool canMove;
    public bool hoodOn;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
     
        if (!canMove)
        {
            animator.SetBool("isWalking", false);
            return;
        }

        if (axisValue != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (hoodOn)
        {
            animator.SetBool("hoodOn", true);
        }
        else 
        {
            animator.SetBool("hoodOn", false);
        }
        MovementInput();
        FlipXRenderer();


    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    private void MovementInput()
    {
        axisValue = Input.GetAxis("Horizontal");           
    }
    private void HorizontalMovement()
    {
        if (!canMove)
        {
            rigidBody.velocity = Vector2.zero;
        }
        else
        {
            rigidBody.velocity = new Vector2(axisValue * movementSpeed, 0f);
        }
      
    }
    private void FlipXRenderer()
    {
       
        if (axisValue < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (axisValue > 0)
        {
            spriteRenderer.flipX = false;
        }
        
    }

    private void StepSound(AudioClip clip)
    {
        audioSource.pitch = Random.Range(0.6f, 1f);
        audioSource.PlayOneShot(clip);
    }
}
