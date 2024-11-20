using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeedField;
    [SerializeField] private float _jumpForceField;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rb2D;
    private Animator _animator;

    private float _horizontalInput;

    private float _velocityX;
    private float _velocityY;

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
        
        if (Mathf.Abs(_velocityY - _rb2D.velocity.normalized.y) > 0.005f)
            _velocityY = Mathf.Lerp(_velocityY, _rb2D.velocity.normalized.y, Time.deltaTime * 12);

        if (Mathf.Abs(_velocityX - _rb2D.velocity.normalized.x) > 0.005f)
            _velocityX = Mathf.Lerp(_velocityX, _rb2D.velocity.normalized.x, Time.deltaTime * _moveSpeed);

        _animator.SetFloat("x", _velocityX);
        _animator.SetFloat("y", _velocityY);

    }

    private void Inputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }
}
