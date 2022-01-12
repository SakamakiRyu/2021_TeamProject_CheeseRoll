using System.Collections;
using UnityEngine;

/// <summary>
/// �^�C�g���V�[���ɂ̂ݑ��݂���R���|�[�l���g
/// </summary>
public class TitleControl : MonoBehaviour
{
    /// <summary>��ʃt�F�[�h������N���X</summary>
    [SerializeField]
    private CircleFade _fade;

    /// <summary>�V�[���J�ڑO�̑ҋ@����</summary>
    [SerializeField]
    private float _waitTime;

    private void Awake()
    {
        _fade.FadeOut();
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Title") return;

        if (Input.anyKeyDown)
        {
            AudioManager.Instance.PlaySE(AudioManager.SEtype.TitleTap);
            StartCoroutine(WaitForCoroutine());
        }
    }

    private IEnumerator WaitForCoroutine()
    {
        _fade.FadeIn();
        yield return new WaitForSeconds(_waitTime);
        SceneManager.Instance.GoNextScene("NewStageSelect");
    }
}
