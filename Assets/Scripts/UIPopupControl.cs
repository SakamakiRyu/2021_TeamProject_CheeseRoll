using UnityEngine;

public class UIPopupControl : MonoBehaviour
{
    public static UIPopupControl Instance { get; private set; } = null;

    [SerializeField]
    private GameObject _obj;

    private Animator _animator;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        TryGetComponent(out _animator);
        _obj.SetActive(false);
    }

    /// <summary>
    /// ゲームオーバーUIを表示する
    /// </summary>
    public void ShowGameOverWindow()
    {
        if (_animator is null) return;

        _animator.SetTrigger("Popup");
    }
}
