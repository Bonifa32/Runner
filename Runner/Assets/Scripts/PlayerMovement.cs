using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private Vector3 _jumpVector;
    [SerializeField] private GameObject _groundRay;
    [SerializeField] private GameObject _player;
    
    private Rigidbody2D _rb;
    private Vector3 _normalScale;
    private Vector3 _slideScale;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _normalScale = new Vector3(_player.transform.localScale.x, _player.transform.localScale.y);
        _slideScale = new Vector3(_player.transform.localScale.x, _player.transform.localScale.y / 2);
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
   
    private void Update()
    {
        Movement();
        Jump(CheckGround());    
        Slide(CheckGround());
    }

    private bool CheckGround()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(_groundRay.transform.position, Vector2.down);

        if (hitGround.collider != null)
        {
            if (hitGround.distance <= 0.1f)
               return true;            
        }
        return false;
    }

    private void Movement()
    {
        _rb.transform.position += _moveVector * Time.deltaTime;
    }

    private void Jump(bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(_jumpVector);
            print(_rb.velocity);
        }
    }

    private void Slide(bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {           
            StartCoroutine(SlideCoroutine());
        }

        IEnumerator SlideCoroutine()
        {
            _player.transform.localScale = _slideScale;
            _rb.constraints =  RigidbodyConstraints2D.FreezeRotation;
            _player.transform.localPosition = new Vector3(4.4f, 0.779f);
            yield return new WaitForSeconds(2);
            _player.transform.localScale = _normalScale;
            _rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;        
        }


    }


    
}
