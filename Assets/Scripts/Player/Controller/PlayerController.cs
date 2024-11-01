using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private FrameInput frameInput;
    private Vector2 frameVelocity;

    [Range(0.01f, 0.99f)]
    public float HorizontalDeadZoneThreshold = 0.1f; //Minimum input required before recognized;
    [Range(0f, 0.5f)]
    public float GrounderDistance = 0.05f; //Distance for grounded check raycast;
    public float JumpPower = 36; //velocity of the jump;
    [Tooltip("The maximum vertical movement speed")]
    public float MaxFallSpeed = 40; //max falling speed
    public float FallAcceleration = 110; //player's falling acceleration to the maximum speed
    
    
    public LayerMask PlayerLayer;
    private bool cachedQueriesStartInColliders;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        cachedQueriesStartInColliders = Physics2D.queriesStartInColliders;
    }

    private void Update()
    {

        GatherInput();
    }

    private void GatherInput()
    {
        frameInput = new FrameInput()
        {
            JumpDown = Input.GetButtonDown("Jump"),
            JumpHeld = Input.GetButton("Jump"),
            Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
        };

        frameInput.Move.x = Mathf.Abs(frameInput.Move.x) < HorizontalDeadZoneThreshold ? 0 : Mathf.Sign(frameInput.Move.x);

        if (frameInput.JumpDown)
        {
            jumpToConsume = true;
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();

        HandleJump();
        // HandleDirection();
        HandleGravity();
        //
        ApplyMovement();
    }

    #region GroundCheck
    
    private bool grounded;

    private void GroundCheck()
    {
        Physics2D.queriesStartInColliders = false;

        bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.down, GrounderDistance, PlayerLayer);

        if (!grounded && groundHit)
        {
            grounded = true;
        }
        else if (grounded && !groundHit)
        {
            grounded = false;
        }

        Physics2D.queriesStartInColliders = cachedQueriesStartInColliders;
    }
    
    #endregion

    #region Jump

    private bool jumpToConsume;

    private void HandleJump()
    {
        if(!jumpToConsume) return;
        
        if (grounded)
        {
            ExecuteJump();
        }
        
        jumpToConsume = false;
    }

    private void ExecuteJump()
    {
        frameVelocity.y = JumpPower;
    }

    #endregion

    #region Gravity

    private void HandleGravity()
    {
        frameVelocity.y = Mathf.MoveTowards(frameVelocity.y, -MaxFallSpeed, FallAcceleration * Time.fixedDeltaTime);
    }

    #endregion
    
    private void ApplyMovement() => rb.velocity = frameVelocity;


    private struct FrameInput
    {
        public bool JumpDown;
        public bool JumpHeld;
        public Vector2 Move;
    }
}
