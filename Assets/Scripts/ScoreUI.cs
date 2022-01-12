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

    [SerializeField] Animation _completeDishUi;
    [SerializeField] Image _completeDishImage;
    [SerializeField] Sprite[] _curentStageCompleteDishSprite;
    int _completeDishIndex;
    private void Start()
    {
        // ScoreUiSetup();
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
            _foods[i].name = ScoreManager.Instance.ScoreStructure.FoodsList[i];
        }

        _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
        _foods[ScoreManager.Instance.ScoreStructure.FoodsList.Length].name = "BurntFood";
        _foods[ScoreManager.Instance.ScoreStructure.FoodsList.Length].GetComponent<Image>().sprite = _foodSprite[Array.IndexOf(_foodSpriteItemNames, "Chili")];
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
                CheckSetFoods();
            }
        }
    }

    public void BurntFoodUi()
    {
        _foods[_foods.Count - 1].GetComponentInChildren<Text>().text = $"×{ScoreManager.Instance.ScoreStructure.BurntFoodCount}";
    }

    void CheckSetFoods()
    {
        if (ScoreManager.Instance.ScoreStructure.FoodsNums.All(x => x >= 1) && _completeDishIndex == 0)//もし1セット揃ってたら
        {
            _completeDishImage.sprite = _curentStageCompleteDishSprite[_completeDishIndex];
            _completeDishUi.Play();
            _completeDishIndex++;
        }
        else if (ScoreManager.Instance.ScoreStructure.FoodsNums.All(x => x >= 2) && _completeDishIndex == 1)
        {
            _completeDishImage.sprite = _curentStageCompleteDishSprite[_completeDishIndex];
            _completeDishUi.Play();
            _completeDishIndex++;
        }
        else if (ScoreManager.Instance.ScoreStructure.FoodsNums.All(x => x == 3) && _completeDishIndex == 2)
        {
            _completeDishImage.sprite = _curentStageCompleteDishSprite[_completeDishIndex];
            _completeDishUi.Play();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < _foods.Count; i++)
            {
                ScoreManager.Instance.ScoreStructure.ScoreUp(_foods[i].name);
            }
        }
    }
}
