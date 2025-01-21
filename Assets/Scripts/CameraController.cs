using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _lookSensitivity = 0.1f;

    void Update()
    {
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;

                transform.Rotate(Vector3.up, delta.x * _lookSensitivity);

                float verticalRotation = -delta.y * _lookSensitivity;
                Vector3 currentRotation = Camera.main.transform.localEulerAngles;
                currentRotation.x += verticalRotation;
                Camera.main.transform.localEulerAngles = currentRotation;
            }
        }
    }
}