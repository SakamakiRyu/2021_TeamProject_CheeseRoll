using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField]
    public float _clearTime;
    [SerializeField]
    public int _foodsNum;
    [SerializeField]
    public int _ngFoodsNum;
    [SerializeField]
    public float _score;
    [SerializeField]
    Text[] _texts;
    [SerializeField]
    GameObject scoreUIPanel;
    [SerializeField]
    Transform _dish;
    public GameObject _dishObject;

    private void Start()
    {
        //ShowScoreUI();
        SetScores();
    }

    public void ShowScoreUI()
    {
        scoreUIPanel.SetActive(true);
    }

    void SetScores()
    {
        _texts[0].text = _clearTime.ToString();
        _texts[1].text = _foodsNum.ToString();
        _texts[2].text = _ngFoodsNum.ToString();
        _texts[3].text = _score.ToString();

        Instantiate(_dishObject, _dish);
    }

    public void  GetScores(float time,int foodsQuantity,int ngFoodsQuantity,float score,GameObject dish)
    {
        _clearTime = time;
        _foodsNum = foodsQuantity;
        _ngFoodsNum = ngFoodsQuantity;
        _score = score;
        _dishObject = dish;
    }
}
