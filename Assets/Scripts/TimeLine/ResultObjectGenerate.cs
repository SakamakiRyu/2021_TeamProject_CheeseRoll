using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultObjectGenerate : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;
    [SerializeField] Transform[] _parents;
    [SerializeField] StarFiller _star;
    [SerializeField] 

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

        int getFoodsNum = 0;
        if (ScoreManager.Instance.ScoreStructure.FoodsNums != null)
        {
            for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsNums.Length; i++)
            {
                getFoodsNum += 1;
            }
        }
        if (getFoodsNum == 0)
        {
            getFoodsNum = 10;//デバッグ用
        }

        for (int i = 0; i < getFoodsNum; i++)//今は_prefabs.Length回まわしてますが、ここの数字は取った具材の種類(getFoodsNum)になります
        {
            Instantiate(_prefabs[i], _parents[i]);
        }

        TimeLineManager timeLineManager = GetComponent<TimeLineManager>();
        timeLineManager.PlayTimeLine(0);//0は仮です
    }

    public void StarFillStart()
    {
        int i = ScoreManager.Instance.GetStar();
        switch (i)
        {
            case 2:
                _star.StarFill(1);
                break;

            case 3:
                _star.StarFill(1.5f);
                break;

            case 4:
                _star.StarFill(2);
                break;

            case 5:
                _star.StarFill(2.5f);
                break;

            case 6:
                _star.StarFill(3);
                break;

            default:
                break;
        }
    }
}
