using System.Collections;
using UnityEngine;

/// <summary>
/// タイトルシーンにのみ存在するコンポーネント
/// </summary>
public class TitleControl : MonoBehaviour
{
    /// <summary>画面フェードをするクラス</summary>
    [SerializeField]
    private CircleFade _fade;

    /// <summary>シーン遷移前の待機時間</summary>
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
