using UnityEngine;

public class UIPopupControl : MonoBehaviour
{
    public static UIPopupControl Instance { get; private set; } = null;

    private Animator _animator;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TryGetComponent(out _animator);
    }

    /// <summary>
    /// �Q�[���I�[�o�[UI��\������
    /// </summary>
    public void ShowGameOverWindow()
    {
        if (_animator is null) return;

        _animator.SetTrigger("Popup");
    }
}
