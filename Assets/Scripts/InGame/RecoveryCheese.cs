using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryCheese : MonoBehaviour
{

    [SerializeField] int _recoveryValue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Cheese>())
        {
            other.gameObject.GetComponent<Cheese>().GetDamage(-_recoveryValue);
        }
    }
}
