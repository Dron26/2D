using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Transform))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsGround;
    private const float _groundedRadius = 1f;
    private const float _ceilingRadius = .1f;
    private float _crouchSpeed = .36f;
    private float _maxSpeed = 10f;
    private float _jumpForce = 200f;
    private bool _isGrounded;
    private bool _isFacingRight = true;
    private bool _jump;
    private bool _flip;
    private Transform _groundCheck; 
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer =GetComponent<SpriteRenderer>();
        _flip = _spriteRenderer.flipX;
        _animator = GetComponent<Animator>();
        _groundCheck =transform.GetChild(0);
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        _isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                _isGrounded = true;
        }

        _animator.SetBool(HashAnimNames.Ground, _isGrounded);
        _animator.SetFloat(HashAnimNames.vSpeedFloat, _rigidbody2D.velocity.y);

        Move(_jump);
        _jump = false;
    }

    private void Update()
    {
        if (!_jump)
        {
            _jump = Input.GetKey(KeyCode.Space);
        }
    }

    private void Move(bool jump)
    {       
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        _animator.SetBool(HashAnimNames.Crouch, crouch);      

        float move = Input.GetAxis("Horizontal");

        if (_isGrounded)
        {
            if (crouch)
            {
                move = move * _crouchSpeed;
            }

            _animator.SetFloat(HashAnimNames.SpeedFloat, Mathf.Abs(move));
            _rigidbody2D.velocity = new Vector2(move * _maxSpeed, _rigidbody2D.velocity.y);

            if (move > 0 && !_isFacingRight)
            {
                Flip();
            }
            else if (move < 0 && _isFacingRight)
            {
                Flip();
            }
        }

        if (_isGrounded & jump & _animator.GetBool(HashAnimNames.Ground))
        {
            _isGrounded = false;
            _animator.SetBool(HashAnimNames.Ground, false);
             _rigidbody2D.AddForce(new Vector2(1f, _jumpForce));
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _flip = !_flip;
        _spriteRenderer.flipX = _flip;
    }
}




