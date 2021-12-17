using UnityEngine;

/// <summary>
/// 音の管理クラス
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private CriAtomSource _BGMSource;

    [SerializeField]
    private AudioClip[] _bgmClips;

    [SerializeField]
    private CriAtomSource _SESource;

    [SerializeField]
    private AudioClip[] _seClips;

    /// <summary>
    /// BGMのcueName
    /// </summary>
    public enum BGMtype
    {
        None = -1,
        /// <summary>ゲーム中</summary>
        Game,
        /// <summary>メイン</summary>
        Main,
        /// <summary>追跡</summary>
        Chase
    }

    public enum SEtype
    {
        None = -1
    }

    // CryAtomSource の cueSheet と cueNameを変更す
    // ることで鳴らす音の素材を変更する。

    /// <summary>
    /// BGMの設定をする
    /// </summary>
    /// <param name="type">設定するBGM</param>
    public void SetBGM(BGMtype type)
    {
        _BGMSource.Stop();
        _BGMSource.cueName = $"BGM_{type}";
    }

    /// <summary>
    /// BGMの再生をする
    /// </summary>
    public void PlayBGM()
    {
        _BGMSource.Play();
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    /// <param name="se"></param>
    public void PlaySE(SEtype se)
    {

    }
}
