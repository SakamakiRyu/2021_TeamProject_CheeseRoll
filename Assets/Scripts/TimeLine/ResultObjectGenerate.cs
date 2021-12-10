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

        for (int i = 0; i < getFoodsNum; i++)//¡‚Í_prefabs.Length‰ñ‚Ü‚í‚µ‚Ä‚Ü‚·‚ªA‚±‚±‚Ì”Žš‚ÍŽæ‚Á‚½‹ïÞ‚ÌŽí—Þ(getFoodsNum)‚É‚È‚è‚Ü‚·
        {
            Instantiate(_prefabs[i], _parents[i]);
        }

        TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
        timeLineManager.PlayTimeLine(0);//0‚Í‰¼‚Å‚·
    }
}
