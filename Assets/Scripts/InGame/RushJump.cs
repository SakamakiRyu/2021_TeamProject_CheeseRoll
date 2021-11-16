using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushJump : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]
    float _jumpPower;

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(_rb);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _rb = null;
            if (other.TryGetComponent(out _rb))
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
                Debug.Log(_rb);
            }
        }
    }
}
