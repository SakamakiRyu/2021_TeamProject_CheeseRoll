using UnityEngine;

/// <summary>
/// ���̊Ǘ��N���X
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
    /// BGM��cueName
    /// </summary>
    public enum BGMtype
    {
        None = -1,
        /// <summary>�Q�[����</summary>
        Game,
        /// <summary>���C��</summary>
        Main,
        /// <summary>�ǐ�</summary>
        Chase
    }

    public enum SEtype
    {
        None = -1
    }

    // CryAtomSource �� cueSheet �� cueName��ύX��
    // �邱�ƂŖ炷���̑f�ނ�ύX����B

    /// <summary>
    /// BGM�̐ݒ������
    /// </summary>
    /// <param name="type">�ݒ肷��BGM</param>
    public void SetBGM(BGMtype type)
    {
        _BGMSource.Stop();
        _BGMSource.cueName = $"BGM_{type}";
    }

    /// <summary>
    /// BGM�̍Đ�������
    /// </summary>
    public void PlayBGM()
    {
        _BGMSource.Play();
    }

    /// <summary>
    /// SE��炷
    /// </summary>
    /// <param name="se"></param>
    public void PlaySE(SEtype se)
    {

    }
}
