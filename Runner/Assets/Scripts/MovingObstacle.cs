using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float _amp = 0.25f;
    [SerializeField] private float _freq = 2;
    private float _t = 0;
    private float _offset = 0;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        _t += Time.deltaTime;
        _offset = _amp * Mathf.Sin(_t * _freq);
        transform.position = _startPos + new Vector3(0, _offset, 0);
    }
}
