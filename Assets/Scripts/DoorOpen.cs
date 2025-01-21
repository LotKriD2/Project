using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] float _shrinkDuration = 2f;
    [SerializeField] Vector3 _targetScale = new Vector3(10, 1, 0.1f);

    private Vector3 _initialScale;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialScale = transform.localScale;
        _initialPosition = transform.position;
        StartCoroutine(ShrinkObject());
    }

    private IEnumerator ShrinkObject()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _shrinkDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _shrinkDuration;

            transform.localScale = Vector3.Lerp(_initialScale, _targetScale, progress);

            float offset = (_initialScale.y - transform.localScale.y) / 2f;
            transform.position = new Vector3(_initialPosition.x, _initialPosition.y + offset, _initialPosition.z);

            yield return null;
        }

        transform.localScale = _targetScale;
        transform.position = new Vector3(_initialPosition.x, _initialPosition.y + (_initialScale.y - _targetScale.y) / 2f, _initialPosition.z);
    }
}
