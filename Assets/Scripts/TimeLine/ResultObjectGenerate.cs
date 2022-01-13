using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultObjectGenerate : MonoBehaviour
{
    GameObject[] _prefabs;
    [SerializeField]
    Transform[] _parents;

    [SerializeField]
    bool _debugMode;
    [SerializeField]
    GameObject _debugFood;

    private void Start()
    {
        if (_debugMode)
        {
            Instantiate(_debugFood, _parents[0]);
            TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
            timeLineManager.PlayTimeLine(0);
        }
        else
        {
            AudioManager.Instance.PlaySE(AudioManager.SEtype.Fall);
            GeneratePrefabs();
        }
    }

    public void GeneratePrefabs()
    {
        if (ScoreManager.Instance.ScoreStructure.FoodsObject != null)
        {
            _prefabs = ScoreManager.Instance.ScoreStructure.FoodsObject;
        }

        for (int i = 0; i < _prefabs.Length; i++)
        {
            if (ScoreManager.Instance.ScoreStructure.FoodsNums[i] != 0)
            {
                GameObject inst = Instantiate(_prefabs[i], _parents[i]);
                inst.transform.localPosition = Vector3.zero;
            }
        }

        TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
        timeLineManager.PlayTimeLine(0);
    }
}
