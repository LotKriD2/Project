using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonTouchController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] Joystick _joystick;
    [SerializeField] float _speed = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_joystick.Horizontal(), 0, _joystick.Vertical());
        _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
    }
}

