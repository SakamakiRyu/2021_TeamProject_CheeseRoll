using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultObjectGenerate : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;
    [SerializeField] Transform[] _parents;

    private void Start()
    {
        GeneratePrefabs();
    }

    public void GeneratePrefabs()
    {
        _prefabs = ScoreManager.Instance.ScoreStructure.FoodsObject;
        int getFoodsNum = 0;
        foreach (var item in ScoreManager.Instance.ScoreStructure.FoodsNums)
        {
            if (item > 0)
            {
                getFoodsNum += 1;
            }
        }

        for (int i = 0; i < getFoodsNum; i++)//今は_prefabs.Length回まわしてますが、ここの数字は取った具材の種類(getFoodsNum)になります
        {
            Instantiate(_prefabs[i], _parents[i]);
        }

        TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
        timeLineManager.PlayTimeLine(0);//0は仮です
    }
}
