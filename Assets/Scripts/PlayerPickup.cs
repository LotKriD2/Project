using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] Transform _holdPosition;
    [SerializeField] float _moveSpeed = 10f;

    private GameObject _heldObject = null;
    private Rigidbody _heldObjectRb = null;

    void Update()
    {
        HandlePickup();
    }

    private void FixedUpdate()
    {
        if (_heldObject != null)
        {
            MoveHeldObject();
        }
    }

    private void HandlePickup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    if (_heldObject == null)
                    {
                        PickUpObject(hit.collider.gameObject);
                    }
                    else
                    {
                        DropObject();
                    }
                }
            }
        }
    }

    private void PickUpObject(GameObject obj)
    {
        _heldObject = obj;
        _heldObjectRb = obj.GetComponent<Rigidbody>();

        if (_heldObjectRb != null)
        {
            _heldObjectRb.useGravity = false;
            _heldObjectRb.drag = 10f;
            _heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void DropObject()
    {
        if (_heldObject != null)
        {
            if (_heldObjectRb != null)
            {
                _heldObjectRb.useGravity = true;
                _heldObjectRb.drag = 0f;
                _heldObjectRb.constraints = RigidbodyConstraints.None;
            }

            _heldObject = null;
            _heldObjectRb = null;
        }
    }

    private void MoveHeldObject()
    {
        Vector3 targetPosition = _holdPosition.position;
        Vector3 moveDirection = (targetPosition - _heldObject.transform.position);

        if (_heldObjectRb != null)
        {
            _heldObjectRb.velocity = moveDirection * _moveSpeed;
        }
    }
}
