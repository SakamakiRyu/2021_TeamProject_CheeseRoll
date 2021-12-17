using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    Sprite[] _foodSprite;
    string[] _foodSpriteItemNames;

    [SerializeField]
    GameObject _foodImage;

    [SerializeField]
    GameObject _foodPanelUi;

    List<GameObject> _foods = new List<GameObject>();

    private void Start()
    {
        // ScoreUiSetup();
    }
    /// <summary>
    /// ÉXÉeÅ[ÉWÇÃêHçﬁÇUIÇ…ê›íËÇ∑ÇÈ
    /// </summary>
    public void ScoreUiSetup()
    {
        if (ScoreManager.Instance is null)
        {
            return;
        }

        _foodSprite = Resources.LoadAll<Sprite>("zen_guzai");
        _foodSpriteItemNames = new string[_foodSprite.Length];
        for (int i = 0; i < _foodSpriteItemNames.Length; i++)
        {
            _foodSpriteItemNames[i] = _foodSprite[i].name;
        }
        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
            _foods[i].GetComponent<Image>().sprite = _foodSprite[Array.IndexOf(_foodSpriteItemNames, ScoreManager.Instance.ScoreStructure.FoodsList[i])];
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
                CheckSetFoods();
            }
        }
    }

    public void BurntFoodUi()
    {
        _foods[_foods.Count - 1].GetComponentInChildren<Text>().text = $"Å~{ScoreManager.Instance.ScoreStructure.BurntFoodCount}";
    }

    void CheckSetFoods()
    {
        if (ScoreManager.Instance.ScoreStructure.FoodsNums.All(x => x <= 1))
        {

        }
        else if (ScoreManager.Instance.ScoreStructure.FoodsNums.All(x => x <= 2))
        {

        }
        else if (ScoreManager.Instance.ScoreStructure.FoodsNums.All(x => x <= 3))
        {

        }
    }
}
