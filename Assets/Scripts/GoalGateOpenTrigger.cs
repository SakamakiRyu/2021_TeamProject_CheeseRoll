using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGateOpenTrigger : MonoBehaviour
{
    [SerializeField]
    Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.CrossFadeInFixedTime("OPEN", 0.25f);
        }
    }
}
