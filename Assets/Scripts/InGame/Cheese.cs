using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField]
    StageMover _move;
    float _z;

    private void Awake()
    {
        _z = this.transform.localPosition.z;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //速度を固定
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = _move.MoveSpeed;
        velocity.x = 0;
        _rigidbody.velocity = velocity;
        //位置を固定
        Vector3 pos = this.transform.localPosition;
        pos.z = _z + _move.transform.position.z;
        pos.x = 0;
        this.transform.localPosition = pos;
    }
}
