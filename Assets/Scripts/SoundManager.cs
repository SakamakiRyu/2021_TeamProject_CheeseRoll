using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 音声の再生を行う
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

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
    /// 効果音を一回再生する
    /// </summary>
    /// <param name="soundName"></param>
    public void PlaySE(string soundName)
    {
        //ここを記述
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="bgmName"></param>
    public void PlayBGM(string bgmName)
    {
        //ここを記述
    }
}
