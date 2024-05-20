using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private float _protein;
    private float _maxProtein = 100;
    public float addProtein;
    public RectTransform valueRectTransform;
    public float becomeBigger;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    
    private CharacterController _characterController;
    
    void Start()
    {
        CursorLock();
        _characterController = GetComponent<CharacterController>();
        DrawProtein();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && valueRectTransform.anchorMax.x >= 1)
        {
            speed +=speed;
            jumpForce +=jumpForce;
            _protein = 0;
            DrawProtein();
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
        _moveVector = Vector3.zero;
        Movement();
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if(Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if(Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if(Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if(Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    public void AddProtein()
    {
        transform.localScale += Vector3.one * becomeBigger;
        _protein += addProtein;
        if(valueRectTransform.anchorMax.x < 1)
        {
            DrawProtein();
        }
    }

    public void DrawProtein()
    {
        valueRectTransform.anchorMax = new Vector2(_protein / _maxProtein, 1);
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
