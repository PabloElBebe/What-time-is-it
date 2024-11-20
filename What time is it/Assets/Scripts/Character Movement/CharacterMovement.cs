using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeedField;
    [SerializeField] private float _jumpForceField;
    [SerializeField] private LayerMask _layerMask;
    
    private Rigidbody2D _rb2D;
    private Animator _animator;

    private float _horizontalInput;
    private float _verticalInput;
    
    private float _moveSpeed => _moveSpeedField;
    private float _jumpForce => _jumpForceField;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Inputs();
        Movement();
        Rotate();
        Animate();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Movement()
    {
        if (_rb2D == null)
            return;

        _rb2D.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb2D.velocity.y);
    }

    private void Rotate()
    {
        Quaternion rotation = transform.rotation;
        float rotateAngle = 0;

        if (_horizontalInput < 0)
            rotateAngle = 180;
        
        transform.rotation = Quaternion.Euler(rotation.x, rotateAngle, rotation.z);
    }
    
    private void Jump()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, 4.6f, _layerMask);
        
        if (_rb2D == null || !hit2D)
            return;

        _rb2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void Animate()
    {
        if (_animator == null || _rb2D == null)
            return;
        
        _animator.SetFloat("x", _rb2D.velocity.x);
        _animator.SetFloat("y", _rb2D.velocity.y);
    }
    
    private void Inputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}
