using UnityEngine;

/// <summary>
/// 音の管理クラス
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private CriAtomSource _BGMSource;

    [SerializeField]
    private CriAtomSource _SESource;

    /// <summary>
    /// BGMのcueName
    /// </summary>
    public enum BGMtype
    {
        None,
        /// <summary>ゲーム中</summary>
        Game,
        /// <summary>メイン</summary>
        Main,
        /// <summary>追跡</summary>
        Chase
    }

    public enum SEtype
    {
        None
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
}
