using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアの管理を行う
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    ///<summary>スコアの最大値</summary>
    public int MaxScoreValue = 10;

    [SerializeField]
    ///<summary>現在のスコア</summary>
    private int _score = 0;

    ///<summary>もし想定していた値を超えていても最大値を渡す</summary>
    public int Score
    {
        get => Mathf.Clamp(_score, 0, MaxScoreValue);
        set => _score = Mathf.Clamp(value, 0, MaxScoreValue);
    }
    private void Awake()
    {
        MakeSingle();
    }

    private void MakeSingle()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// 受け取った値をスコアに加算する
    /// </summary>
    /// <param name="plusScore">加算する値</param>
    public void ScorePlus(int plusScore)
    {
        Mathf.Clamp(_score += plusScore, 0, MaxScoreValue);//最大値から出ないようにする
    }
}
