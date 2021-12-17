using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkGameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StageManager.Instance.GameOver();
            StageManager.Instance.StopStage();
            foreach (var collider in this.GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }
        }

    }
}
