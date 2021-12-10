using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    [Header("フォークのスピード")]
    [SerializeField] float _forkSpeed;

    [Header("フォークの移動範囲")]
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("GameOver");
            StageManager.Instance.GameOver();
            StageManager.Instance.StopStage();
            foreach (var collider in this.GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }
        }
      
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Stop");
        StageManager.Instance.StopStage();
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Start");
        StageManager.Instance.StageStart();
        foreach (var collider in this.GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }
    }
}
