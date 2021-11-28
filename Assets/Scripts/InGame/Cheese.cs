using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public static Cheese Instance;

    Rigidbody _rigidbody;
    [SerializeField]
    float _hp;
    float _maxHp;
    [SerializeField]
    float _minSize;
    float _maxSize;
    [SerializeField]
    float _plateDamageOverTimes;
    [SerializeField]
    StageMover _move;
    [SerializeField, Range(0.0f, 1.0f)]
    float _onHitSensitivity = 0.5f;
    [Header("チーズが鉄板のどれぐらい後ろについてくるか")]
    [SerializeField]
    float _zPosition = -1f;

    public float ZPosition => _zPosition;
    public float HP => _hp;
    public float MaxHp => _maxHp;

    float _speed = 0;

    private void Awake()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody>();
        _maxSize = transform.localScale.x;
        _maxHp = _hp;
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
        GetPlateDamage();
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
    void GetPlateDamage()
    {
        GetDamage(Time.deltaTime * _plateDamageOverTimes);
    }

    private void UpdateSize()
    {
        float size = _minSize;
        size += (_maxSize - _minSize) * (_hp / _maxHp);
        this.transform.localScale = new Vector3(size, size, size);
    }

    public void GetDamage(float damage)
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _hp = 0;
            StageManager.Instance.GameOver();
        }
        else if (_hp > 100)
        {
            _hp = 100;
        }
        UpdateSize();
    }
}
