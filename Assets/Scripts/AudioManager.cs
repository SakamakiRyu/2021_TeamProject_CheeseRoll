using UnityEngine;

/// <summary>
/// ���̊Ǘ��N���X
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
    /// BGM��炷
    /// </summary>
    /// <param name="bgm">�炷BGM</param>
    public void PlayBGM(BGMtype bgm)
    {
        if (bgm == BGMtype.None) return;

        _bgmSource.cueName = $"BGM_{bgm}";
        _bgmSource.Play();
    }

    /// <summary>
    /// ME��炷
    /// </summary>
    /// <param name="me">�炷ME</param>
    public void PlayME(METype me)
    {
        if (me == METype.None) return;

        _meSource.cueName = $"ME_{me}";
        _meSource.Play();
    }

    /// <summary>
    /// SE��炷
    /// </summary>
    /// <param name="se">�炷SE</param>
    public void PlaySE(SEtype se)
    {
        if (se == SEtype.None) return;
        _seSource.cueName = $"SE_{se}";
        _seSource.Play();
    }
}
