using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// スコアの管理を行う
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance => _instance;

    static ScoreManager _instance;

    public Score ScoreStructure;



    private void Awake()
    {
        MakeSingle();
    }

    private void MakeSingle()
    {
        if (_instance is null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }


    public struct Score
    {
        ///<summary>ステージの食材の配列</summary>
        public string[] FoodsList { get; set; }
        ///<summary>食材の獲得数</summary>
        public int[] FoodsNums { get; set; }
        ///<summary>何人前か？</summary>
        public int Dishes { get; set; }
        ///<summary>スコアのUIのコンポーネント</summary>
        public ScoreUI ScoreUI { get; set; }
        ///<summary>獲得した焦げた具材の数</summary>
        public int BurntFoodCount { get; set; }

        public GameObject[] FoodsObject { get; set; }

        public GameObject[] DishsObject { get; set; }

        public BorderAndScore[] TimeBorderAndScore { get; set; }
        public float Time { get; set; }
        public BorderAndScore[] BonusScore { get; set; }
        public float BurntScore { get; set; }
        public float[] DishsScores { get; set; }
        public float[] StarBorders { get; set; }

        public Score(
            string[] foodsList,
            int[] foodsNums,
            int dishes,
            ScoreUI scoreUI,
            GameObject[] foodsObject,
            GameObject[] dishObject,
            BorderAndScore[] timeBorderAndScore,
            BorderAndScore[] bonusScore,
            float burntScore, 
            float[] dishsScores, 
            float[] starBorders)
        {
            this.FoodsList = foodsList;
            this.FoodsNums = foodsNums;
            this.Dishes = dishes;
            this.ScoreUI = scoreUI;
            this.BurntFoodCount = 0;
            this.FoodsObject = foodsObject;
            this.DishsObject = dishObject;
            this.TimeBorderAndScore = timeBorderAndScore;
            this.Time = 0;
            this.BonusScore = bonusScore;
            this.BurntScore = burntScore;
            this.DishsScores = dishsScores;
            this.StarBorders = starBorders;
        }
        /// <summary>
        /// スコアを加算する
        /// 食材を獲得した場合呼び出してください
        /// </summary>
        /// <param name="food">獲得した食材</param>
        public void ScoreUp(string food)
        {
            for (int i = 0; i < FoodsList.Length; i++)
            {
                if (FoodsList[i] == food)
                {
                    FoodsNums[i]++;
                    ScoreUI.ScoreUpUi(food);
                }
            }
        }
        /// <summary>
        /// 焦げた食材を取得したときに呼ばれて焦げた食材のカウントが増える
        /// 焦げた食材を獲得した場合呼び出してください
        /// </summary>
        public void BurntFoodCountUp()
        {

            BurntFoodCount++;
            //ScoreUI.ScoreUpUi("BurntFood");

            ScoreUI.BurntFoodUi();
        }

    }
    /// <summary>
    /// 最終的なスコアを計算する
    /// </summary>
    /// <returns>最終的なスコア</returns>
    public int ScoreCalculation()
    {
        //クリア時間スコア
        float timeScore = 1;
        for (int i = 0; i < ScoreStructure.TimeBorderAndScore.Length; i++)
        {
            timeScore = ScoreStructure.TimeBorderAndScore[i].score;
            if (ScoreStructure.Time < ScoreStructure.TimeBorderAndScore[i].border)
            {
                break;
            }
        }

        //ボーナススコア
        float bonus = 1;//何個とったか？
        int fCount = GetGetedFoodCount();
        for (int i = 0; i < ScoreStructure.BonusScore.Length; i++)
        {
            bonus = ScoreStructure.BonusScore[i].score;
            if (fCount >= ScoreStructure.BonusScore[i].border)
            {
                break;
            }
        }

        //何人前か？
        int dishes = 3;
        for (int k = 0; k < ScoreStructure.FoodsNums.Length; k++)
        {
            dishes = Mathf.Min(dishes, ScoreStructure.FoodsNums[k]);
        }
        float dishScore = ScoreStructure.DishsScores[dishes];

        return (int)(timeScore * bonus * dishScore - ScoreStructure.BurntFoodCount * ScoreStructure.BurntScore);//最終的なスコア
    }

    /// <summary>
    /// 評価に応じた完成料理を返す
    /// </summary>
    /// <returns></returns>
    public GameObject GetDish()
    {
        return ScoreStructure.DishsObject[0];
    }
    /// <summary>
    /// スコアの星の数を返す
    /// </summary>
    /// <returns></returns>
    public int GetStar()
    {
        int score = ScoreCalculation();
        int star = 2;
        for (int i = 0; i < ScoreStructure.StarBorders.Length; i++)
        {
            if (score < ScoreStructure.StarBorders[i])
            {
                break;
            }
            star++;
        }
        return star;
    }

    public int GetTime()
    {
        return (int)ScoreStructure.Time;
    }

    public int GetGetedFoodCount()
    {
        int a = 0;
        foreach (var item in ScoreStructure.FoodsNums)
        {
            a += item;
        }
        return a;
    }

    public int GetNGFoodCount()
    {
        return ScoreStructure.BurntFoodCount;
    }
}
