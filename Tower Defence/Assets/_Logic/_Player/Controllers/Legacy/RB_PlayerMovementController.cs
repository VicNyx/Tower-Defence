using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;

    [Header("Jump")]
    [SerializeField] private float jumpForce; //1.2 is a good place to start
    [SerializeField] private int maxJumps;
    [SerializeField] private int currentJumps;

    [Header("Gravity")]
    [SerializeField] private float fallMultiplier; //1.75 matches will with 1.2 jumpForce

    [Header("Bools")]
    [SerializeField] private bool isGrounded;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentJumps = maxJumps;

        //check for rigidbody
        if(rb == null)
        {
            Debug.LogError("Rigidbody not attached!");
        }
    }

    private void Update()
    {
        GroundCheck();

        //if grounded, refresh currentJumps
        if (isGrounded)
        {
            currentJumps = maxJumps;
        }

        if(Input.GetButtonDown("Jump") && currentJumps > 0)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Movement();
        FallGravity();
    }

    private void Movement()
    {
        //inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //multiplying movement by movementSpeed and by 10
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * 10f * Time.fixedDeltaTime;
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPos);
    }

    private void Jump()
    {
        if(currentJumps > 0)
        {
            //multiplying by jumpForce and by 10
            rb.AddForce(Vector3.up * jumpForce * 10f, ForceMode.Impulse);
            currentJumps--;
        }

    }

    private void GroundCheck() //https://www.reddit.com/r/Unity3D/comments/3c43ua/best_way_to_check_for_ground/
    {
        //raycast downwards from centre of player transform 
        RaycastHit hit;
        float distance = 1.2f;
        Vector3 dir = new Vector3(0f, -1f);

        if(Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FallGravity() //@Omar Santiago - Better Jump in Unity
    {
        if(!isGrounded)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }
    }

}

/*@Tysonn J. Smith 2023
 * 
 * for less floaty jumping @Omar Santiago - Better Jump in Unity
 * https://www.youtube.com/watch?v=Os-RX3XCwvU&t=86s
 * 
 * 
 * 
 */