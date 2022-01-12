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
    //[SerializeField]
    public float _score;
    [SerializeField]
    Text[] _texts;
    [SerializeField]
    GameObject scoreUIPanel;
    [SerializeField]
    Transform _dish;
    public GameObject _dishObject;
    [SerializeField]
    StarFiller _star;

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
        GetScores();

        _texts[0].text = _clearTime.ToString();
        _texts[1].text = _foodsNum.ToString();
        _texts[2].text = _ngFoodsNum.ToString();
        _texts[3].text = _score.ToString();

        _dishObject = ScoreManager.Instance.GetDish();

        if (_dishObject != null)
        {
            Instantiate(_dishObject, _dish);
        }
    }

    public void  GetScores()
    {
        _clearTime = ScoreManager.Instance.GetTime();
        _foodsNum = ScoreManager.Instance.GetGetedFoodCount();
        _ngFoodsNum = ScoreManager.Instance.GetNGFoodCount();
        _score = ScoreManager.Instance.ScoreCalculation();

        //Debug.Log(ScoreManager.Instance.GetTime());
        //Debug.Log(ScoreManager.Instance.GetNGFoodCount());
        //Debug.Log(ScoreManager.Instance.GetNGFoodCount());
        //Debug.Log(_score);
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
