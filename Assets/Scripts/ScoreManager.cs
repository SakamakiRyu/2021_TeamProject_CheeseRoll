using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// スコアの管理を行う
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Score ScoreStructure;

    private int[] _dishesScore = { 10, 30, 60 };

   

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
        public Score(string[] foodsList,int[] foodsNums,int dishes,ScoreUI scoreUI,GameObject[] foodsObject,GameObject[] dishObject )
        {
            this.FoodsList = foodsList;
            this.FoodsNums = foodsNums;
            this.Dishes = dishes;
            this.ScoreUI = scoreUI;
            this.BurntFoodCount = 0;
            this.FoodsObject = foodsObject;
            this.DishsObject = dishObject;
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
            ScoreUI.ScoreUpUi("BurntFood");

        }
       
    }
    /// <summary>
    /// 最終的なスコアを計算する
    /// </summary>
    /// <returns>最終的なスコア</returns>
    public int ScoreCalculation()
    {
        if (Instance.ScoreStructure.FoodsNums == null)
        {
            return 0;
        }
        int bonus = 0;//何個とったか？
        Instance.ScoreStructure.FoodsNums.ToList().ForEach(x => bonus += x);

        int dishes = 0;//何人前か？
        bool isBreak = false;//trueなら抜け出す
        for (int i = 0; i < Instance.ScoreStructure.Dishes; i++)
        {
            for (int k = 0; k < Instance.ScoreStructure.FoodsNums.Length; k++)
            {
                Instance.ScoreStructure.FoodsNums[k]--;
                if (Instance.ScoreStructure.FoodsNums[k] > 0)
                {
                    isBreak = true;
                    break;

                }

            }
            if (isBreak)
            {
                break;
            }
            dishes = _dishesScore[i];
        }

        return bonus * dishes - Instance.ScoreStructure.BurntFoodCount;//最終的なスコア
    }
}
