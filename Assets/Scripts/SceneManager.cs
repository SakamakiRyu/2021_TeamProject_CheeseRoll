﻿using System.Collections;
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

    [SerializeField]
    private bool _toGameImmediately;


    private void StartTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    /// <summary>
    /// シーン遷移する
    /// </summary>
    /// <param name="nextSceneName">シーン指定 シーンの名前</param>
    public void GoNextScene(string nextSceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
