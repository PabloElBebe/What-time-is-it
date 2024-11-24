using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeedField;
    [SerializeField] private float _jumpForceField;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Transform _handTransform;
    [SerializeField] private GameObject _bottlePrefab;
    [SerializeField] private Vector2 _bottleSpawnOffset;

    private Rigidbody2D _rb2D;
    private Animator _animator;

    private float _horizontalInput;

    private float _velocityX;
    private float _velocityY;

    private int _bottlesAmount;

    private float _moveSpeed => _moveSpeedField;
    private float _jumpForce => _jumpForceField;

    private bool _isOnPickableItem;
    private Bottle _currentBottleObject;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
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

        if (_currentBottleObject != null && Input.GetKeyDown(KeyCode.E))
        {
            _currentBottleObject.GetComponent<Bottle>().TakeBottle(transform);
            TakeBottle();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bottle>())
        {
            _currentBottleObject = other.GetComponent<Bottle>();

            if (BasicSaveSystem.LoadBoolData("pickUpHint"))
                return;

            List<string> phrases = new List<string>();
            phrases.Add("Обычно, чтобы поднять предмет, я использовал «E»...");
            
            HelpSystems.OpenThoughts(phrases);
            
            BasicSaveSystem.SaveBoolData(true, "pickUpHint");
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_currentBottleObject != null)
            _currentBottleObject = null;
    }

    private void TakeBottle()
    {
        _bottlesAmount++;
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
        
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, 4.6f, _layerMask);
        
        if (Mathf.Abs(_velocityY - _rb2D.velocity.normalized.y) > 0.005f && !hit2D)
            _velocityY = Mathf.Lerp(_velocityY, _rb2D.velocity.normalized.y, Time.deltaTime * 12);
        else if (Mathf.Abs(_velocityY) > 0.001f)
            _velocityY= Mathf.Lerp(_velocityY, 0, Time.deltaTime * 12);

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
