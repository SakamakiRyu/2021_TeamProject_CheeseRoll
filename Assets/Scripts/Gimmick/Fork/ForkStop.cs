using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkStop : MonoBehaviour
{
    [SerializeField]
    GameObject _fork;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageManager.Instance.StopStage();
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageManager.Instance.StageStart();
            foreach (var collider in _fork.GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }
        }
    }
}
