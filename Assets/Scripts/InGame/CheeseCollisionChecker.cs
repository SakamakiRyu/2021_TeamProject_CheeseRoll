using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �`�[�Y�̒��n��������
/// </summary>
public class CheeseCollisionChecker : MonoBehaviour
{
    bool isCollision;
    bool isCollisionPre;

    public bool IsGroundEnter { get; private set; }

    public void GroundEnterUsed() => IsGroundEnter = false;

    private void FixedUpdate()
    {
        if (isCollision != isCollisionPre)
        {
            if (isCollision)
            {
                IsGroundEnter = true;
            }
        }
        isCollisionPre = isCollision;
        isCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollision = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        isCollision = true;
    }
}
