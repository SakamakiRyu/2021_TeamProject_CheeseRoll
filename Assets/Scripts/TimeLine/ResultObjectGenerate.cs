using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultObjectGenerate : MonoBehaviour
{
    GameObject[] _prefabs;
    [SerializeField] Transform[] _parents;
    [SerializeField] GameObject _debug;

    private void Start()
    {
        GeneratePrefabs();
    }

    public void GeneratePrefabs()
    {
        if (ScoreManager.Instance.ScoreStructure.FoodsObject != null)
        {
            _prefabs = ScoreManager.Instance.ScoreStructure.FoodsObject;
        }
        else
        {
            Instantiate(_debug, _parents[0]);
        }

        //int getFoodsNum = 0;
        //if (ScoreManager.Instance.ScoreStructure.FoodsNums != null)
        //{
        //    Debug.Log(ScoreManager.Instance.ScoreStructure.FoodsNums);
        //    for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsNums.Length; i++)
        //    {
        //        getFoodsNum += 1;
        //    }
        //}
        //if (getFoodsNum == 0)
        //{
        //    getFoodsNum = 10;//デバッグ用
        //}
        for (int i = 0; i < _prefabs.Length; i++)
        {
            GameObject inst = Instantiate(_prefabs[i], _parents[i]);
            inst.transform.localPosition = Vector3.zero;
        }

        TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
        timeLineManager.PlayTimeLine(0);
    }
}
