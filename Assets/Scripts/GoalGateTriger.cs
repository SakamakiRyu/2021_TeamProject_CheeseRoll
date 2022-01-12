using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGateTriger : MonoBehaviour
{
    [SerializeField]
    Transform _effectPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StageManager.Instance.GateIn();
            GameObject e = EffectManager.Instance?.PlayEffect(EffectManager.EffectType.Goal, _effectPos.position);
            e.GetComponent<ParticleSystem>()?.Play();
        }
    }
}
