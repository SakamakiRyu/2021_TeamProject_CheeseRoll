using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ステージを動かす
/// </summary>
public class StageMover : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private float _defaultMoveSpeed;
    private bool _isMoving;

    public float MoveSpeed => _moveSpeed;
    public float DefaultMoveSpeed => _defaultMoveSpeed;
    public bool IsMoving => _isMoving;

    private void Start()
    {
        _defaultMoveSpeed = _moveSpeed;
    }

    private void Update()
    {
        if (!_isMoving)
        {
            return;
        }
        Vector3 pos = transform.localPosition;
        pos.z += _moveSpeed * Time.deltaTime;
        transform.localPosition = pos;
    }

    public void MoveStart()
    {
        _isMoving = true;
    }

    /// <summary> 移動速度を０にする </summary>
    public void MoveStop()
    {
        _moveSpeed = 0;
        _isMoving= false;
    }
}
