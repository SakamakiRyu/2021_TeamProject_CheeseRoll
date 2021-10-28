using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField]
    StageMover _move;
    [SerializeField, Range(0.0f, 1.0f)]
    float _onHitSensitivity = 0.5f;
    float _z;
    float speed;

    private void Awake()
    {
        _z = this.transform.localPosition.z;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateSpeed();
    }

    private void FixedUpdate()
    {
        //速度を固定
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = speed;
        velocity.x = 0;
        _rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //タテ速度の変更
        Vector3 nomal = collision.GetContact(0).normal;
        float bai = -(nomal.z / nomal.y);
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = speed;
        velocity.y = Mathf.Max(speed * bai * _onHitSensitivity, velocity.y);
        velocity.x = 0;
        _rigidbody.velocity = velocity;
    }

    private void OnCollisionStay(Collision collision)
    {
        //タテ速度の変更
        Vector3 nomal = collision.GetContact(0).normal;
        float bai = -(nomal.z / nomal.y);
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = speed;
        velocity.y = Mathf.Max(speed * bai * _onHitSensitivity, velocity.y);
        velocity.x = 0;
        _rigidbody.velocity = velocity;
    }

    private void UpdateSpeed()
    {
        //本来いるべき座標との差を調べる
        float realZ = this.transform.localPosition.z;
        float z = _z + _move.transform.position.z;
        float sa = z - realZ;
        //差に応じて速度を変化させる
        speed = _move.MoveSpeed + sa;
    }
}
