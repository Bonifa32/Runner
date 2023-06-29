using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private GameObject _ground;
    private bool _isJumpOn;
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private Vector3 _jumpVector;

    void Start()
    {
        _isJumpOn = false;
        _rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        _rb.transform.position += _moveVector * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.transform.position += _jumpVector * Time.deltaTime;
        }
    }
}
