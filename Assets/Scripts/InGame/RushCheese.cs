using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushCheese : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField]
    float _hp;
    [SerializeField]
    float _minSize;
    [SerializeField]
    float _scaleMinusValue;
    float time = 0;
    [SerializeField]
    StageMover _move;
    [SerializeField, Range(0.0f, 1.0f)]
    float _onHitSensitivity = 0.5f;
    float _z;
    float speed;

    /// <summary>
    /// X座標
    /// </summary>
    public float Xpos;

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
        Vector3 pos = transform.position;
        pos.x = Xpos;
        transform.position = pos;
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
    void ChangeScale()
    {
        if (_hp > _minSize)
        {
            if (time > 0.1f)
            {
                _hp -= _scaleMinusValue;
                this.gameObject.transform.localScale = new Vector3(_hp / 100, _hp / 100, _hp / 100);
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }

        }
    }
}
