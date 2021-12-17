using UnityEngine;

/// <summary>
/// 音の管理クラス
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private CriAtomSource _bgmSource;

    [SerializeField]
    private CriAtomSource _meSource;

    [SerializeField]
    private CriAtomSource _seSource;

    private void Awake()
    {
        if (Instance)
        {
            Instance = this;
        }
    }

    public enum BGMtype
    {
        None,
        GamePlay01,
        HotStatas,
        Result,
        StageSelect,
        Title
    }

    public enum METype
    {
        None,
        GameOver,
        Goal
    }

    public enum SEtype
    {
        None,
        BlowTheFire,
        BurnrlngredientsAcquired,
        Button01,
        CancelButton,
        CheeseJump,
        CheeseMelted,
        Fall,
        GameStart,
        IngredientsAcquired,
        IronPlate,
        MouseChewing,
        RecoveryItem,
        SlicerSound,
        TitleTap,
        ResultScore,
        CheeseRoll_01,
        CheeseRoll_02,
        CheeseRoll_random
    }

    /// <summary>
    /// BGMを鳴らす
    /// </summary>
    /// <param name="bgm">鳴らすBGM</param>
    public void PlayBGM(BGMtype bgm)
    {
        _bgmSource.cueName = $"BGM_{bgm}";
        _bgmSource.Play();
    }

    /// <summary>
    /// MEを鳴らす
    /// </summary>
    /// <param name="me">鳴らすME</param>
    public void PlayME(METype me)
    {
        _meSource.cueName = $"ME_{me}";
        _meSource.Play();
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    /// <param name="se">鳴らすSE</param>
    public void PlaySE(SEtype se)
    {
        _seSource.cueName = $"SE_{se}";
        _seSource.Play();
    }
}
