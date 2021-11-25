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
    /// �X�e�[�W�̐H�ނ�UI�ɐݒ肷��
    /// </summary>
    public void ScoreUiSetup()
    {
        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
            _foods[i].name = ScoreManager.Instance.ScoreStructure.FoodsList[i];
        }

        _foods.Add(Instantiate(_foodImage, _foodPanelUi.transform));
        _foods[ScoreManager.Instance.ScoreStructure.FoodsList.Length].name = "BurntFood";
    }
    /// <summary>
    /// �l�������H�ނ�UI�ɔ��f����
    /// </summary>
    /// <param name="food">�l�������H��</param>
    public void ScoreUpUi(string food)
    {
        for (int i = 0; i < ScoreManager.Instance.ScoreStructure.FoodsList.Length; i++)
        {
            if (food == _foods[i].name)
            {
                _foods[i].GetComponentInChildren<Text>().text = $"�~{ScoreManager.Instance.ScoreStructure.FoodsNums[i]}";
            }
        }
    }

    public void BurntFoodUi()
    {
        _foods[_foods.Count-1].GetComponentInChildren<Text>().text = $"�~{ScoreManager.Instance.ScoreStructure.BurntFoodCount}";
    }
}
