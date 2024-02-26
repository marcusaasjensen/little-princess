using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;

    [Header("Ground Check")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform orientation;
    
    private bool _readyToJump;
    private bool _grounded;
    private Vector2 _inputDirection;
    private Vector3 _moveDirection;
    private Rigidbody _rb;
    
    public void SetMovementDirection(Vector2 input) => _inputDirection = input;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

        _readyToJump = true;
    }

    private void Update()
    {
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        
        ControlSpeed();
        
        _rb.drag = _grounded ? groundDrag : 0;
    }

    private void FixedUpdate() => MovePlayer();

    public void StartJump()
    {
        if (!_readyToJump || !_grounded)
        {
            return;
        }
        
        _readyToJump = false;

        Jump();

        Invoke(nameof(ResetJump), jumpCooldown);
    }

    private void MovePlayer()
    {
        _moveDirection = orientation.forward * _inputDirection.y + orientation.right * _inputDirection.x;
        _rb.AddForce(_moveDirection.normalized * (moveSpeed * 10f * (_grounded ? 1 : airMultiplier)), ForceMode.Force);
    }

    private void ControlSpeed()
    {
        var velocity = _rb.velocity;
        
        var flatVel = new Vector3(velocity.x, 0f, velocity.z);

        if (!(flatVel.magnitude > moveSpeed))
        {
            return;
        }
        
        var limitedVel = flatVel.normalized * moveSpeed;
        _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
    }

    private void Jump()
    {
        var velocity = _rb.velocity;
        velocity = new Vector3(velocity.x, 0f, velocity.z);
        _rb.velocity = velocity;

        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    
    private void ResetJump() => _readyToJump = true;
}