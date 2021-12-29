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
