using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private FrameInput frameInput;
    private Vector2 frameVelocity;
    private float time;

    [Range(0.01f, 0.99f)]
    public float HorizontalDeadZoneThreshold = 0.1f; //Minimum input required before recognized
    [Range(0f, 0.5f)]
    public float GrounderDistance = 0.05f; //Distance for grounded check raycast
    public float JumpPower = 36; //velocity of the jump
    public float MaxSpeed = 14; //max horizontal speedd
    public float MinFallSpeed = 20; //min vertical speed
    public float MaxFallSpeed = 40; //max vertical speed
    public float Acceleration = 120; //ground horizontal acceleration
    public float FallAcceleration = 110; //player's falling acceleration to the maximum speed
    public float GroundDeceleration = 60; //pace at which the player comes to a stop
    public float AirDeceleration = 30; //deceleration in air only after stopping input mid-air
    public float JumpBuffer = .2f; //time to consider the input before actually touching the ground to jump
    public float JumpEndEarlyGravityModifier = 3; //The gravity multiplier added when jump is released early
    public float JumpApexThreshold = 36f;
    public float ApexBonus = 0.2f;
    [Range(0f, -10f)]
    public float GroundingForce = -1.5f; //A constant downward force applied while grounded. Helps with apex points
    public float CoyoteTime = .15f; //Coyote jump window
    
    
    public LayerMask GroundLayer;
    private bool cachedQueriesStartInColliders;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        cachedQueriesStartInColliders = Physics2D.queriesStartInColliders;
    }

    private void Update()
    {
        time += Time.deltaTime;
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
            timeJumpWasPressed = time;
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();

        HandleJump();
        HandleDirection();
        HandleGravity();
        ApplyMovement();
    }

    #region GroundCheck

    private float frameLeftGrounded = float.MinValue;
    private bool grounded;

    private void GroundCheck()
    {
        Physics2D.queriesStartInColliders = false;

        //bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.down, GrounderDistance, GroundLayer);
        bool groundHit = Physics2D.BoxCast(col.bounds.center, col.size, 0, Vector2.down, GrounderDistance, GroundLayer);
        
        //landed on the ground
        if (!grounded && groundHit)
        {
            grounded = true;
            bufferedJumpUsable = true;
            jumpEndedEarly = false;
            coyoteUsable = true;
        }
        //left the ground
        else if (grounded && !groundHit)
        {
            grounded = false;
            frameLeftGrounded = time;
        }

        Physics2D.queriesStartInColliders = cachedQueriesStartInColliders;
    }
    
    #endregion

    #region Jump

    private bool jumpToConsume;
    private float timeJumpWasPressed;
    private bool bufferedJumpUsable;
    private bool jumpEndedEarly;
    private bool coyoteUsable;

    private bool HasBufferedJump => bufferedJumpUsable && time < timeJumpWasPressed + JumpBuffer;
    private bool CanUseCoyote => coyoteUsable && !grounded && time < frameLeftGrounded + CoyoteTime;

    private void HandleJump()
    {
        if(!jumpEndedEarly && !grounded && !frameInput.JumpHeld && rb.velocity.y > 0) jumpEndedEarly = true;
        
        if(!jumpToConsume && !HasBufferedJump) return;
        
        if (grounded || CanUseCoyote)
        {
            ExecuteJump();
        }
        
        jumpToConsume = false;
    }

    private void ExecuteJump()
    {
        jumpEndedEarly = false;
        bufferedJumpUsable = false;
        coyoteUsable = false;
        timeJumpWasPressed = 0;
        frameVelocity.y = JumpPower;
    }

    #endregion

    #region Direction

    private void HandleDirection()
    {
        if (frameInput.Move.x == 0)
        {
            var deceleration = grounded ? GroundDeceleration : AirDeceleration;
            frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, 0, deceleration * Time.fixedDeltaTime);
        }
        else
        {
            frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, frameInput.Move.x * MaxSpeed, Acceleration * Time.fixedDeltaTime);
        }
    }

    #endregion

    #region Gravity
    
    private float _apexPoint;
    private float _fallSpeed;

    private void HandleGravity()
    {
        if (grounded && frameVelocity.y <= 0f)
        {
            frameVelocity.y = GroundingForce; //the velocity shouldn't be 0 for the apex of the jump detection
        }
        else
        {
            #region ApexModifiers
            
            //at the apex of the jump the character gets a small horizontal boost and anti-gravity for better control
            _apexPoint = Mathf.InverseLerp(JumpApexThreshold, 0, Mathf.Abs(rb.velocity.y));
            var apexBonus = frameInput.Move.x * ApexBonus * _apexPoint;
            frameVelocity.x += apexBonus * Time.fixedDeltaTime;
            _fallSpeed = Mathf.Lerp(MinFallSpeed, MaxFallSpeed, _apexPoint);
            
            #endregion

            var inAirGravity = FallAcceleration;
            if(jumpEndedEarly && frameVelocity.y > 0) inAirGravity *= JumpEndEarlyGravityModifier; //if the jump button was unpressed the character falls faster
            frameVelocity.y = Mathf.MoveTowards(frameVelocity.y, -_fallSpeed, inAirGravity * Time.fixedDeltaTime);
        }
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
