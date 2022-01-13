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

    public enum Type
    {
        None,
        BGM,
        ME,
        SE
    }

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
    /// ���̍Đ��������I�Ɏ~�߂�
    /// </summary>
    /// <param name="type">�~�߂鉹�̎��</param>
    public void StopSound(Type type)
    {
        switch (type)
        {
            case Type.None:
                break;
            case Type.BGM:
                {
                    _bgmSource.Stop();
                }
                break;
            case Type.ME:
                {
                    _meSource.Stop();
                }
                break;
            case Type.SE:
                {
                    _seSource.Stop();
                }
                break;
        }
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
        // �Đ����̉����~�߂Ă���A�V���ɍĐ�����
        _seSource.Stop();

        _seSource.cueName = $"SE_{se}";
        _seSource.Play();
    }
}
