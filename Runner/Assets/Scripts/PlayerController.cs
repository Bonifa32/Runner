using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private Vector3 _jumpVector;
    [SerializeField] private GameObject _groundRay;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _obstacleParent;

    private SpriteRenderer _sr;
    private Collider2D[] _colObstacles;
    private int _obstacleCount = 0;
    private bool _isSliding;
    private Rigidbody2D _rb;
    private Vector3 _normalScale;
    private Vector3 _slideScale;
    private float _changeSpeed = 0.1f;

    private void Start()
    {
        _isSliding = false;
        _rb = GetComponent<Rigidbody2D>();
        _normalScale = new Vector3(_player.transform.localScale.x, _player.transform.localScale.y);
        _slideScale = new Vector3(_player.transform.localScale.x, _player.transform.localScale.y / 2);
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _obstacleCount = _obstacleParent.transform.childCount;
        _colObstacles = new Collider2D[_obstacleCount];

        for(int i = 0; i < _obstacleCount; i++)
        {
            _colObstacles[i] = _obstacleParent.transform.GetChild(i).GetComponent<Collider2D>();
        }
                   
    }
   
    private void Update()
    {
        Movement();
        Jump(CheckGround());    
        Slide(CheckGround());
    }

    private void OnEnable()
    {
        ImmortalityBoost.BoostTaken += OnTakeImmortality;
    }

    private void OnDisable()
    {
        ImmortalityBoost.BoostTaken -= OnTakeImmortality;
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
        _moveVector.x += _changeSpeed * Time.deltaTime;
    }

    private void Jump(bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !_isSliding)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(_jumpVector);           
        }
    }

    private void Slide(bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCode.S) && isGrounded && !_isSliding)
        {           
            StartCoroutine(SlideCoroutine());
        }

    }

    private IEnumerator SlideCoroutine()
    {
        _isSliding = true;
        _player.transform.localScale = _slideScale;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _player.transform.localPosition = new Vector3(_player.transform.position.x, _player.transform.position.y - 0.53f);
        yield return new WaitForSeconds(1f);
        _player.transform.localScale = _normalScale;
        _rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        _isSliding = false;
    }

    private IEnumerator ImmortalityCoroutine()
    {
        for (int i = 0; i < _obstacleCount; i++)
        {
            _colObstacles[i].enabled = false;
        }
        
        yield return new WaitForSeconds(5);
        for (int i = 0; i < _obstacleCount; i++)
        {
            _colObstacles[i].enabled = true;
        }
    }

    private void OnTakeImmortality()
    {
        StartCoroutine(ImmortalityCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "finish")
        {         
            Time.timeScale = 0;
        }
    }

   







}
