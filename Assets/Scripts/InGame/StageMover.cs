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

    private void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.z += _moveSpeed * Time.deltaTime;
        transform.localPosition = pos;
    }
}
