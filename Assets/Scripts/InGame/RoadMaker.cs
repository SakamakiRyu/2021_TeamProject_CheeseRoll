using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    //生成したオブジェクトの収納先
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private float _splitTime;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _splitTime)
        {
            _timer -= _splitTime;
            Split();
        }
        StretchRoad();
    }

    private void Split()
    {

    }

    private void StretchRoad()
    {

    }
}
