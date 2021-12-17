using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    [Header("�t�H�[�N�̃X�s�[�h")]
    [SerializeField] float _forkSpeed;

    [Header("�t�H�[�N�̈ړ��͈�")]
    [SerializeField] float _forkMovementRange;

    Vector3 _pos;

    void Start()
    {
        _pos = transform.position;
    }


    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 v = _pos;
        v.y += _forkMovementRange * Mathf.Sin(_forkSpeed * Time.time);
        transform.position = v;
    }

  

   
}
