using UnityEngine;

/// <summary>
/// âπÇÃä«óùÉNÉâÉX
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
    /// BGMÇñ¬ÇÁÇ∑
    /// </summary>
    /// <param name="bgm">ñ¬ÇÁÇ∑BGM</param>
    public void PlayBGM(BGMtype bgm)
    {
        _bgmSource.cueName = $"BGM_{bgm}";
        _bgmSource.Play();
    }

    /// <summary>
    /// MEÇñ¬ÇÁÇ∑
    /// </summary>
    /// <param name="me">ñ¬ÇÁÇ∑ME</param>
    public void PlayME(METype me)
    {
        _meSource.cueName = $"ME_{me}";
        _meSource.Play();
    }

    /// <summary>
    /// SEÇñ¬ÇÁÇ∑
    /// </summary>
    /// <param name="se">ñ¬ÇÁÇ∑SE</param>
    public void PlaySE(SEtype se)
    {
        _seSource.cueName = $"SE_{se}";
        _seSource.Play();
    }
}
