﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] Transform _endTransform;
    [SerializeField] StageMover _stageMover;
    [SerializeField] RoadMaker _roadMaker;
    [SerializeField] Transform _cheese;
    //[SerializeField] float _stopDistance = -1.5f;
    [SerializeField] bool _testStop;

    [SerializeField] GameObject _testResultButton;

    private void Start()
    {
        if (_testStop)
        {
            Vector3 kari = _endTransform.position;
            kari.z = 10;
            _endTransform.position = kari;
        }
    }

    private void Update()
    {
        if (_endTransform.position.z < _cheese.position.z)
        {
            //_stageMover.MoveSpeed = 0;
            //Debug.Log("静止予定" + _cheese.position);

            StageClear();
        }
    }

    private void StageClear()
    {
        _stageMover.MoveStop();
        _testResultButton.SetActive(true);
        _roadMaker.NowPlay = false;
    }
}