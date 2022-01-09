using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    private void Awake()
    {
        MakeSingle();
    }

    private void Start()
    {
        StartTitle();
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

    [Header("False なら Title に移動します")]
    [SerializeField]
    private bool _toGameImmediately;

    [SerializeField]
    private bool _noLoadTitleOnStart = false;

    [SerializeField]
    private string _immediatelySceneName = "Game";

    private void StartTitle()
    {
        if (_noLoadTitleOnStart)
        {
            return;
        }
        if (_toGameImmediately == true)
        {
            GoNextScene(_immediatelySceneName);
        }
        else
        {
            GoNextScene("Title");
        }
    }

    /// <summary>
    /// シーン遷移する
    /// </summary>
    /// <param name="nextSceneName">シーン指定 シーンの名前</param>
    public void GoNextScene(string nextSceneName)
    {
        bool isChengeBGM = false;

        switch (nextSceneName)
        {
            case "Title":
                {
                    AudioManager.Instance.PlayBGM(AudioManager.BGMtype.Title);
                    isChengeBGM = true;
                    break;
                }

            case "NewStageSelect":
                {
                    AudioManager.Instance.PlayBGM(AudioManager.BGMtype.StageSelect);
                    isChengeBGM = true;
                    break;
                }

            case "Result":
                {
                    AudioManager.Instance.PlaySE(AudioManager.SEtype.Fall);
                    AudioManager.Instance.PlayBGM(AudioManager.BGMtype.Result);
                    isChengeBGM = true;
                    break;
                }
        }

        if (!isChengeBGM)
        {
            AudioManager.Instance.PlayBGM(AudioManager.BGMtype.GamePlay01);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
