using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアの管理を行う
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

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
}
