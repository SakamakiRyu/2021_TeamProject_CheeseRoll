﻿using UnityEngine;

public class MouseBeheiviour : MonoBehaviour
{
    /// <summary>アニメーター</summary>
    [SerializeField]
    private Animator _animator = null;

    /// <summary>自身の座標</summary>
    [SerializeField]
    private Transform _myTransform = null;

    /// <summary>移動速度</summary>
    [Header("反復速度")]
    [SerializeField]
    private float _upDownSpeed = 1.0f;

    [Header("迫ってくる速さ")]
    [SerializeField]
    private float _moveSpeed = 1.0f;

    /// <summary>上下の移動量</summary>
    [Header("移動量")]
    [SerializeField]
    private float _upDownMoveValue = 5.0f;

    [Header("ダメージ")]
    [SerializeField]
    int _damage = 10;

    private float _gapRemoveValue;

    private void Start()
    {
        _gapRemoveValue = _myTransform.position.y;

    }

    private void Update()
    {
        if (StageManager.Instance?.State != StageManager.StageState.InGame)
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        var v3 = _myTransform.position;
        var y = _upDownMoveValue * Mathf.Sin(Time.time * _upDownSpeed);
        v3.y = y + _gapRemoveValue;
        v3.z = v3.z - _moveSpeed * Time.deltaTime;
        _myTransform.position = v3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_animator) return;

        if (other.CompareTag("Player"))
        {
            Cheese.Instance.ChengeFace();
            AudioManager.Instance.PlaySE(AudioManager.SEtype.MouseChewing);
            Vector3 hitpos = (_myTransform.position + other.transform.position) / 2.0f;
            EffectManager.Instance.PlayEffect(EffectManager.EffectType.HitObstacle, hitpos);
            AteCheese();
            Debug.Log("hit cheese");
        }
    }

    /// <summary>
    /// アニメーションで、チーズを食べ終わった際に呼ぶイベント
    /// </summary>
    public void AteCheese()
    {
        //StageManager.Instance.GameOver();
        Cheese.Instance?.GetDamage(_damage);
    }
}
