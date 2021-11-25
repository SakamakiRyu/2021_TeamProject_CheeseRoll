using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] bool _isRotate = true;

    [SerializeField] float _rotateSpeed = 2;
    Transform _transform;
    Vector3 _vector3;

    private void Start()
    {
        _transform = this.transform;
        _vector3 = _transform.rotation.eulerAngles;
    }

    private void FixedUpdate()
    {
        if (_isRotate == true)
        {
            _vector3.y += _rotateSpeed;
            _transform.rotation = Quaternion.Euler(_vector3);
        }
    }
}
