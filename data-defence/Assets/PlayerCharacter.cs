using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerCharacter : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldowm;
    public float airMuiltiplier;
    bool readyToJump;


    [Header("Keybinds")]
    public KeyCode jumpkey = KeyCode.Space;

    [Header("Ground check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;



    public Transform orientation;

    float horizontalInput;
    float verticalInput;


    Vector3 moveDirection;

    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpkey) && readyToJump && grounded)
        {
            readyToJump = false;
            JumpForce();

            Invoke(nameof(ResetJump), jumpCooldowm);
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        SpeedControl();
        JumpForce();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMuiltiplier, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);


        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);        }
    }
    private void JumpForce()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
