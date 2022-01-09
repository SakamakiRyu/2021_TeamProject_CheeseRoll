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
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public enum BGMtype
    {
        None,
        Title,
        StageSelect,
        GamePlay01,
        HotStatas,
        Result
    }

    public enum METype
    {
        None,
        Goal,
        GameOver
    }

    public enum SEtype
    {
        None,
        TitleTap,
        Button01,
        GameStart,
        CancelButton,
        IngredientsAcquired,
        BurntIngredientsAcquired,
        RecoveryItem,
        BlowTheFire,
        SlicerSound,
        MouseChewing,
        CheeseMelted,
        CheeseRoll_01,
        CheeseRoll_02,
        IronPlate,
        CheeseJump,
        Fall,
        ResultScore,
        CheeseRoll_random
    }

    /// <summary>
    /// BGMを鳴らす
    /// </summary>
    /// <param name="bgm">鳴らすBGM</param>
    public void PlayBGM(BGMtype bgm)
    {
        if (bgm == BGMtype.None) return;

        _bgmSource.cueName = $"BGM_{bgm}";
        _bgmSource.Play();
    }

    /// <summary>
    /// MEを鳴らす
    /// </summary>
    /// <param name="me">鳴らすME</param>
    public void PlayME(METype me)
    {
        if (me == METype.None) return;

        _meSource.cueName = $"ME_{me}";
        _meSource.Play();
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    /// <param name="se">鳴らすSE</param>
    public void PlaySE(SEtype se)
    {
        if (se == SEtype.None) return;
        _seSource.cueName = $"SE_{se}";
        _seSource.Play();
    }
}
