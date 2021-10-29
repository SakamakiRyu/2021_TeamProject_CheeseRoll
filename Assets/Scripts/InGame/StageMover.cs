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

    public float MoveSpeed => _moveSpeed;

    private void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.z += _moveSpeed * Time.deltaTime;
        transform.localPosition = pos;
    }

    /// <summary> 移動速度を０にする </summary>
    public void MoveStop()
    {
        _moveSpeed = 0;
    }
}
