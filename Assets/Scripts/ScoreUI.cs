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
    /// ÉXÉeÅ[ÉWÇÃêHçﬁÇUIÇ…ê›íËÇ∑ÇÈ
    /// </summary>
    public void ScoreUiSetup()
    {
        //Debug.Log(ScoreManager.Instance.ScoreStructure.FoodsList.Length);
        // NullReferenceException: Object reference not set to an instance of an object.

        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
            _foods[i].name = ScoreManager.Instance.ScoreStructure.FoodsList[i];
        }

        _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
        _foods[ScoreManager.Instance.ScoreStructure.FoodsList.Length].name = "BurntFood";
    }
    /// <summary>
    /// älìæÇµÇΩêHçﬁÇÃUIÇ…îΩâfÇ∑ÇÈ
    /// </summary>
    /// <param name="food">älìæÇµÇΩêHçﬁ</param>
    public void ScoreUpUi(string food)
    {
        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            if (food == _foods[i].name)
            {
                _foods[i].GetComponentInChildren<Text>().text = $"Å~{ScoreManager.Instance.ScoreStructure.FoodsNums[i]}";
            }
        }
    }

    public void BurntFoodUi()
    {
        _foods[_foods.Count-1].GetComponentInChildren<Text>().text = $"Å~{ScoreManager.Instance.ScoreStructure.BurntFoodCount}";
    }
}
