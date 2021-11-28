using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 音声の再生を行う
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    /// <summary>
    /// 流す音のデータの配列
    /// </summary>
    [SerializeField]
    private AudioClip[] _audios;

    private AudioSource _se;
    private AudioSource _bgm;
    public enum SoundType
    {
        HomeBGM, // ==0
        StageSelectBGM, // ==1
        GameBGM, // ==2
        PinchBGM, // ==3
        //SE追加予定
    }
    private void Awake()
    {
        MakeSingle();
        _se = GetComponent<AudioSource>();
        _bgm = GetComponent<AudioSource>();
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
    /// 効果音を一回再生する。鳴らしたい音に合うステートを引数に渡す。
    /// </summary>
    /// <param name="soundName"></param>
    public void PlaySE(SoundType soundName)
    {
        //ここを記述
        _se.PlayOneShot(_audios[(int)soundName]);
    }

    /// <summary>
    /// BGMを再生する。鳴らしたいBGMに合うステートを引数に渡す。
    /// </summary>
    /// <param name="bgmName"></param>
    public void PlayBGM(SoundType bgmName)
    {
        //ここを記述
        _bgm.clip = _audios[(int)bgmName];
        _bgm.loop = true;
        _bgm.Play();
    }
}
