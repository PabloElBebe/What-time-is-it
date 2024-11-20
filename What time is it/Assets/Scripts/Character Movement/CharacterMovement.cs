using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeedField;

    private Rigidbody2D _rb2D;
    private Animator _animator;

    private float _horizontalInput;
    private float _verticalInput;
    
    private float _moveSpeed => _moveSpeedField;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Inputs();
        Movement();
        Animate();
    }

    private void Movement()
    {
        if (_rb2D == null)
            return;

        _rb2D.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb2D.velocity.y);
    }

    private void Jump()
    {
        
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
        _horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        _verticalInput = UnityEngine.Input.GetAxis("Vertical");
    }
}
