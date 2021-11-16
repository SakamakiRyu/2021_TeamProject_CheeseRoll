using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushJump : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]
    float _jumpPower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.TryGetComponent(out Rigidbody rigidbody))
                _rb = other.GetComponent<Rigidbody>();

            if (_rb)
            {
                _rb.AddForce(Vector3.up * _jumpPower);
                Debug.Log("Jump");
            }
        }
    }
}
