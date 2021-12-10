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

        for (int i = 0; i < getFoodsNum; i++)//����_prefabs.Length��܂킵�Ă܂����A�����̐����͎������ނ̎��(getFoodsNum)�ɂȂ�܂�
        {
            Instantiate(_prefabs[i], _parents[i]);
        }

        TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
        timeLineManager.PlayTimeLine(0);//0�͉��ł�
    }
}
