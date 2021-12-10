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
            other.gameObject.GetComponent<Cheese>().GetDamage(_hpDownValue);
        }
    }
}
