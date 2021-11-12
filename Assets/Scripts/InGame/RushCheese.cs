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
    /// X���W
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
        //���x���Œ�
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = speed;
        velocity.x = Xpos;
        _rigidbody.velocity = velocity;
    }

    
    private void UpdateSpeed()
    {
        //�{������ׂ����W�Ƃ̍��𒲂ׂ�
        float realZ = this.transform.localPosition.z;
        float z = _z + _move.transform.position.z;
        float sa = z - realZ;
        //���ɉ����đ��x��ω�������
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
