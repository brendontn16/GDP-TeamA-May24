using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal; //Input float for 2D movement
    public float speed;
    public bool isGrounded = true;
    public bool isJumping = false;
    public bool facingRight;

    Transform playerRotation; //Variable to control player's rotation

    public LayerMask groundLayer; //ground layer so we know if we're above ground

    public Transform groundCheck; //for checking if we're grounded.
    public float groundCheckRadius = 0.1f; //radius around groundcheck for testing 
    public float jumpForce = 20f;
    public CharacterAttack attack;
    public CharacterDataLoader Data;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRotation = GetComponent<Transform>();
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (facingRight)
        {
            
                playerRotation.rotation = Quaternion.Euler(0, 180, 0);
                //Debug.Log("Facing Right");
        }
        else
        {
           
                playerRotation.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("Facing Left");

        }
        if (isGrounded)
        {
            isJumping = false;
        }
    }
   
    public void Movement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        //for crouching, is the player holding down s?
        if(context.ReadValue<Vector2>().y < 0){
            Crouch();
        }
    }

    public void Jump (InputAction.CallbackContext context)
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Debug.Log(isGrounded);

        if (context.performed && isGrounded)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void Crouch(){
        //Set animation trigger for crouch
        //collider related changes
        Debug.Log("Crouching");
    }
}
