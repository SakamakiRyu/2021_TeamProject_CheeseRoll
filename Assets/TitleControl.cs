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

    private void Update()
    {
        if (Input.anyKeyDown)
        {
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