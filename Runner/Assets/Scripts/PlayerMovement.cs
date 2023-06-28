using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 2f;
    private Vector2 moveVector;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        _rb.MovePosition(_rb.position + moveVector * _speed * Time.deltaTime);
    }
}
