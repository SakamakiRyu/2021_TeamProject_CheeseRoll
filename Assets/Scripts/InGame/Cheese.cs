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
    [SerializeField]
    Animator _animator;

    CheeseCollisionChecker _collisionChecker;

    BurningCheese _burningCheese;
    float _damageMultiplication = 1.0f;

    public float ZPosition => _zPosition;
    public float HP => _hp;
    public float MaxHp => _maxHp;

    float _speed = 0;

    private void Awake()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody>();
        _collisionChecker = GetComponent<CheeseCollisionChecker>();
        _maxSize = transform.localScale.x;
        _maxHp = _hp;

        _burningCheese = GetComponent<BurningCheese>();
    }

    private void Update()
    {
        UpdateSpeed();
        UpdateAnimation();
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
        if (collision.gameObject.CompareTag("Road"))
        {
            GetPlateDamage();
        }
    }

    void ChangeSpeed(Collision collision)
    {
        if (_move.IsMoving)
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
        else if(StageManager.Instance.State == StageManager.StageState.PreGame || StageManager.Instance.State == StageManager.StageState.EndGame)
        {
            //デフォルトの移動スピードを採用する
            _speed = _move.DefaultMoveSpeed;
        }
        else
        {
            _speed = 0;
        }


    }

    bool _lr;
    private void UpdateAnimation()
    {
        if (_collisionChecker.IsGroundEnter)
        {
            if (_lr)
            {
                _animator.CrossFade("Ground0", 0.08f);
            }
            else
            {
                _animator.CrossFade("Ground1", 0.08f);
            }
            _lr = !_lr;
            _collisionChecker.GroundEnterUsed();
        }
        _animator.SetBool("IsAir", _collisionChecker.IsAir);
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
        if (_burningCheese.IsBurning == true) { _damageMultiplication = _burningCheese.BurningMultiplication; }
        else { _damageMultiplication = 1.0f; }

        damage *= _damageMultiplication;

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
