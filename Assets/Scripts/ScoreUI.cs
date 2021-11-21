using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    [SerializeField]
     GameObject _foodImage;

    [SerializeField]
     GameObject _foodPanelUi;

    List<GameObject> _foods = new List<GameObject>();

    private void Start()
    {      
        ScoreUiSetup();
    }
    /// <summary>
    /// ステージの食材をUIに設定する
    /// </summary>
    public void ScoreUiSetup()
    {
        if (ScoreManager.Instance is null)
        {
            return;
        }
        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
            _foods[i].name = ScoreManager.Instance.ScoreStructure.FoodsList[i];
        }

        _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
        _foods[ScoreManager.Instance.ScoreStructure.FoodsList.Length].name = "BurntFood";
    }
    /// <summary>
    /// 獲得した食材のUIに反映する
    /// </summary>
    /// <param name="food">獲得した食材</param>
    public void ScoreUpUi(string food)
    {
        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            if (food == _foods[i].name)
            {
                _foods[i].GetComponentInChildren<Text>().text = $"×{ScoreManager.Instance.ScoreStructure.FoodsNums[i]}";
            }
        }
    }
}
