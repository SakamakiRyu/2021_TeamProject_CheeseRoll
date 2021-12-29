using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �`�[�Y�̒��n��������
/// </summary>
public class CheeseCollisionChecker : MonoBehaviour
{
    const float WaitTime = 0.5f;
    bool _isCollision;
    bool _isCollisionPre;
    float _timer;
    public bool IsGroundEnter { get; private set; }
    public bool IsAir { get; private set; }

    public void GroundEnterUsed() => IsGroundEnter = false;

    private void FixedUpdate()
    {
        _timer -= Time.deltaTime;
        _timer = Mathf.Max(-1.0f, _timer);
        if (_isCollision && !_isCollisionPre)
        {
            if (_isCollision && _timer < 0)
            {
                IsGroundEnter = true;
            }
            _timer = WaitTime;
        }
        if (_isCollision)
        {
            IsAir = false;
        }
        else
        {
            IsAir = true;
        }
        _isCollisionPre = _isCollision;
        _isCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isCollision = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        _isCollision = true;
    }
}
