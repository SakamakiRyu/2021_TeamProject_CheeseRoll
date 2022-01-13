using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using System.Linq;
public class Result : MonoBehaviour
{
    [SerializeField]
    ///<summary>スコアを表示するオブジェクト</summary>
    Text _scoreTextUi;

    [SerializeField]
    ///<summary>スコアを表示するオブジェクト</summary>
    Image[] _scoreEvaluationUiImage;
    [SerializeField]
    ///<summary>タイムラインを制御するオブジェクト</summary>
    TimeLineManager _timeLineManager;

    [SerializeField]
    Text[] _sterText;

    ///<summary>ステージの評価スコアの基準値</summary>
    public int[] EvaluationScore = {
            5000,
            10000,
            15000,
            30000,
            50000
    };

    int _scoreValue;
    void Start()
    {
        _scoreValue = ScoreManager.Instance.ScoreCalculation();
        _timeLineManager.PlayTimeLine(0);

    }


    /// <summary>
    /// シグナルに設定するための関数
    /// </summary>
    public void ScoreAnimStart()
    {
        AudioManager.Instance.PlaySE(AudioManager.SEtype.ResultScore);
        StartCoroutine(ScoreAnim());
    }
    /// <summary>
    /// scoreTextに０から獲得スコアまで増やしていく
    /// </summary>
    public IEnumerator ScoreAnim()
    {
        int value = 0;
        while (_scoreValue >= value)
        {

            _scoreTextUi.text = $"スコア　 :　 {value}　/　{10000000}";
            value++;

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(evaluationAnim());
    }
    IEnumerator evaluationAnim()
    {

        if (EvaluationScore[4] <= _scoreValue)
        {
            yield return new WaitForSeconds(1.0f);
            _sterText[0].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[1].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[2].text = "★";
        }
        else if (EvaluationScore[3] <= _scoreValue)
        {
            yield return new WaitForSeconds(1.0f);
            _sterText[0].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[1].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[2].text = "☆";
        }
        else if (EvaluationScore[2] <= _scoreValue)
        {
            yield return new WaitForSeconds(1.0f);
            _sterText[0].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[1].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[2].text = "";
        }
        else if (EvaluationScore[1] <= _scoreValue)
        {
            yield return new WaitForSeconds(1.0f);
            _sterText[0].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[1].text = "☆";
            yield return new WaitForSeconds(1.0f);
            _sterText[2].text = "";
        }
        else if (EvaluationScore[0] <= _scoreValue)
        {
            yield return new WaitForSeconds(1.0f);
            _sterText[0].text = "★";
            yield return new WaitForSeconds(1.0f);
            _sterText[1].text = "";
            yield return new WaitForSeconds(1.0f);
            _sterText[2].text = "";
        }
        else
        {
            _sterText[0].text = "";
            _sterText[1].text = "";
            _sterText[2].text = "";
        }
    }

}
