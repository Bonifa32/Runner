using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _offset;


    private void LateUpdate()
    {
        Vector3 newPosition = _player.transform.position + _offset;
        this.transform.position = newPosition;
    }
}
