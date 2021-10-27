using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
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

   
    /// <summary>
    /// シグナルに設定するための関数
    /// </summary>
    public void ScoreAnimStart()
    {
        StartCoroutine(ScoreAnim());
    }
    /// <summary>
    /// scoreTextに０から獲得スコアまで増やしていく
    /// </summary>
    public IEnumerator ScoreAnim()
    {
        int value = 0;
        while (ScoreManager.Instance.Score >= value)
        {

            _scoreTextUi.text = $"具材獲得数　 :　 {value}　/　{ScoreManager.Instance.MaxScoreValue}";
            value++;

            yield return new WaitForSeconds(0.2f);
        }
    }

   
}
