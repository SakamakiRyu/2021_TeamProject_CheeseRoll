using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float Hp;
    [SerializeField]
    float _minSize;
    [SerializeField]
    float _oneScaleValue;
    float _time = 0;
    [SerializeField]
    StageMover _move;
    [SerializeField, Range(0.0f, 1.0f)]
    float _onHitSensitivity = 0.5f;
    [Header("チーズが鉄板のどれぐらい後ろについてくるか")]
    [SerializeField]
    float _zPosition = -1f;

    public float ZPosition => _zPosition;

    float _speed = 0;

    private void Awake()
    {
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
        velocity.z = _speed;
        velocity.x = 0;
        _rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChangeSpeed(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        ChangeSpeed(collision);
        ChangeScale();
    }

    void ChangeSpeed(Collision collision)
    {
        //タテ速度の変更
        Vector3 nomal = collision.GetContact(0).normal;
        float bai = -(nomal.z / nomal.y);
        //ロードチップがある場合の処理
        RoadChip chip = collision.transform.GetComponent<RoadChip>();
        if (chip)
        {
            nomal = chip.WallVector;
            bai = nomal.y / nomal.z;
        }
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = _speed;
        velocity.y = Mathf.Max(_speed * bai * _onHitSensitivity, velocity.y);
        velocity.x = 0;
        _rigidbody.velocity = velocity;
    }

    private void UpdateSpeed()
    {
        if (_move.IsMoving)
        {
            //本来いるべき座標との差を調べる
            float realZ = this.transform.position.z;
            float z = _zPosition + _move.transform.position.z;
            float sa = z - realZ;
            //差に応じて速度を変化させる
            _speed = _move.MoveSpeed + sa;
        }
        else
        {
            //デフォルトの移動スピードを採用する
            _speed = _move.DefaultMoveSpeed;
        }


    }
    void ChangeScale()
    {
        if (Hp > _minSize)
        {
            if (_time > 0.1f)
            {
                ChangeHpAndScale(-1);
                _time = 0;
            }
            else
            {
                _time += Time.deltaTime;
            }

        }
    }
    public void ChangeHpAndScale(int value)
    {
        var scale = this.gameObject.transform.localScale;
        scale += new Vector3(_oneScaleValue * value, _oneScaleValue * value, _oneScaleValue * value);
        this.gameObject.transform.localScale = new Vector3(Mathf.Clamp(scale.x, _minSize, 1), Mathf.Clamp(scale.y, _minSize, 1), Mathf.Clamp(scale.z, _minSize, 1));
        Hp = Mathf.Clamp(Hp + value, 0, 100);

        Debug.Log(Hp);
    }
}
