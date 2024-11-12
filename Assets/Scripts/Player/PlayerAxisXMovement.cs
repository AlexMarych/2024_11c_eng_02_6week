using UnityEngine;

public class PlayerAxisXMovement : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 3f;
    [SerializeField] public float Gravity = 0.4f;

    private Rigidbody2D _rb;
    //private Vector2 velocity;
    private GroundCheck _groundCheck;
    private float InputHorizontal;
    private PlayerSFXController _playerSFXController;
    private bool isMoving;


    private void Awake()
    {
        _playerSFXController = GetComponent<PlayerSFXController>();
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();
    }


    // Update is called once per frame
    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.AddForce(InputHorizontal * MoveSpeed * Time.deltaTime * Vector2.right);
        _rb.AddForce(Gravity * Time.deltaTime * Vector2.down);

        _rb.velocity *= new Vector2(0.92f, 1f);
    }

    //private void MoveAxisX()
    //{
    //    if (InputHorizontal != 0)
    //    {
    //        _rb.velocity = new Vector2(InputHorizontal * MoveSpeed, _rb.velocity.y);
    //        isMoving = true;
            
    //    }
    //    else if (!_groundCheck.Grounded)
    //    {
    //        isMoving = false;
    //    }
    //    else
    //    {
    //        _rb.velocity = new Vector2(0f, _rb.velocity.y);
    //        isMoving = false ;
    //    }
    //}
    
    public bool IsMoving()
    {
        return _rb.velocity.x != 0;
    }
}
