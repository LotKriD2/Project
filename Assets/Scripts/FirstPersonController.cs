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
        Vector3 input = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        
        Vector3 movement = cameraRight * input.x + cameraForward * input.z;
        _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
    }
}

