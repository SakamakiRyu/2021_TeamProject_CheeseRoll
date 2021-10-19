using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    [SerializeField]
    ///<summary>スコアを表示するオブジェクト</summary>
    Text _scoreTextUi;  
    [SerializeField]
    ///<summary>スコアを表示するオブジェクト</summary>
    Image[] _scoreEvaluationUiImage;

    void Start()
    {
        _scoreTextUi.text = $"具材獲得数　 :　 {ScoreManager.Instance.Score}　/　{ScoreManager.Instance.MaxScoreValue}";

        if (ScoreManager.Instance.Score <= 3)
        {
            _scoreEvaluationUiImage[0].gameObject.SetActive(true);
        }
        else if (ScoreManager.Instance.Score <= 6)
        {
            _scoreEvaluationUiImage[0].gameObject.SetActive(true);
            _scoreEvaluationUiImage[1].gameObject.SetActive(true);
        }
        else
        {
            _scoreEvaluationUiImage[0].gameObject.SetActive(true);
            _scoreEvaluationUiImage[1].gameObject.SetActive(true);
            _scoreEvaluationUiImage[2].gameObject.SetActive(true);
        }
    }

   
    void Update()
    {
        
    }
}
