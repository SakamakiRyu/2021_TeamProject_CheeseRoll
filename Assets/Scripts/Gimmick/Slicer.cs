using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] int _hpDownValue;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Cheese>())
        {
            Debug.Log("Hit");
            other.gameObject.GetComponent<Cheese>().GetDamage(_hpDownValue);
            EffectManager.Instance.PlayEffect(EffectManager.EffectType.HitObstacle, other.transform.position);
            AudioManager.Instance.PlaySE(AudioManager.SEtype.SlicerSound);
            Cheese.Instance.ChengeFace();
        }
    }
}
