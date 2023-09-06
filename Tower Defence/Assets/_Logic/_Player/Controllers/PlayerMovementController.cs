using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private MovementAttributes _movement;

    [Header("Jumping")]
    [SerializeField] private int currentJumps;

    [Header("Bools")]
    [SerializeField] private bool isGrounded;

    private CharacterController cc;
    private Vector3 velocity;
    private float currentSpeed;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        if(cc == null)
        {
            Debug.LogError("No CharacterController Found!");
        }
    }

    private void Start()
    {
        currentSpeed = _movement.StandardSpeed;
        currentJumps = _movement.MaxJumps;
    }

    private void Update()
    {
        HandleMovement();
        GroundCheck();

        if (isGrounded)
        {
            velocity.y = 0f;
            currentJumps = _movement.MaxJumps;
        }

        if (Input.GetButtonDown("Jump") && currentJumps > 0)
        {
            HandleJump();
        }

        if (!isGrounded)
        {
            FallEffect();
        }
    }

    private void HandleMovement()
    {
        //inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //movement logic
        Vector3 movementDir = transform.forward * verticalInput + transform.right * horizontalInput;
        movementDir.Normalize();

        //apply gravity
        velocity.y += _movement.Gravity * Time.deltaTime;
        movementDir += velocity;

        //apply movement
        cc.Move(movementDir * currentSpeed * Time.deltaTime);
    }

    private void HandleJump()
    {
        velocity.y = Mathf.Sqrt(2 * _movement.JumpForce * -_movement.Gravity);
        currentJumps--;
    }

    private void GroundCheck() //https://www.reddit.com/r/Unity3D/comments/3c43ua/best_way_to_check_for_ground/
    {
        //changed from raycast to sphere cast to be more consistent 
        float radius = .2f;
        Vector3 dir = Vector3.down;

        if (Physics.SphereCast(transform.position, radius, dir, out RaycastHit hit, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FallEffect()
    {
        cc.Move(Vector3.down * _movement.FallMultiplier * Time.deltaTime);
    }
}