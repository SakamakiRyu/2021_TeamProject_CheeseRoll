using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Incetance;

    public HighScore[] HighScoreStructurs;

    [SerializeField] Sprite[] dishSprites;

    private void Awake()
    {
        MakeSingle();
    }

    private void MakeSingle()
    {
        if (Incetance is null)
        {
            Incetance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        Sprite[] dishSpriteList = new Sprite[3];

        HighScoreStructurs = new HighScore[dishSprites.Length / 3];
        for (int i = 0; i < dishSprites.Length / 3; i++)
        {
           
            int index = 0;
            for (int k = (i + 1) * 3; k - 1 >= (i + 1) * 3 - 3; k--)
            {
                dishSpriteList[index] = dishSprites[k - 1];
                index++;
            }

            HighScoreStructurs[i] = new HighScore($"Stage{i+1}", dishSpriteList);
            dishSpriteList = new Sprite[3];
        }
    }


    void Update()
    {

    }
    public struct HighScore
    {
        public string StageName { get; set; }

        public Sprite[] DishImages { get; set; }


        public HighScore(string stageName, Sprite[] dishImage)
        {
            this.DishImages = dishImage;
            this.StageName = stageName;
        }

        public int GetHighScore()
        {
            return ScoreManager.Instance.GetHighScore(StageName);
        }

        public Sprite GetDishPic()
        {
            if (ScoreManager.Instance.GetHighScore(StageName) == 6)
            {
                return DishImages[0];
            }
            else if (ScoreManager.Instance.GetHighScore(StageName) >= 2)
            {
                return DishImages[1];
            }
            else
            {
                return DishImages[2];
            }
        }
    }
}
