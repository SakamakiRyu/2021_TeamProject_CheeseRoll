using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeraMouse : MonoBehaviour
{
    /// <summary>�A�j���[�^�[</summary>
    [SerializeField]
    private Animator _animator = null;

    /// <summary>���g�̍��W</summary>
    [SerializeField]
    private Transform _myTransform = null;

    /// <summary>�ړ����x</summary>
    [Header("�������x")]
    [SerializeField]
    private float _upDownSpeed = 1.0f;

    [Header("�����Ă��鑬��")]
    [SerializeField]
    private float _moveSpeed = 1.0f;

    /// <summary>�㉺�̈ړ���</summary>
    [Header("�ړ���")]
    [SerializeField]
    private float _upDownMoveValue = 5.0f;

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
            UpDownByFinger.Instance.ChengeControll();
            Vector3 hitpos = (_myTransform.position + other.transform.position) / 2.0f;
            EffectManager.Instance.PlayEffect(EffectManager.EffectType.HitObstacle, hitpos);
            //�Ƃ�܂����
            AudioManager.Instance.PlaySE(AudioManager.SEtype.MouseChewing);
        }
    }
}
