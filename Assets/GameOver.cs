using UnityEngine;

/// <summary>
/// �Q�[���I�[�o�[���̋���
/// �ŏI�I�ɂ́AStageManager�Ŏ�������
/// </summary>
public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject _go;

    private void Start()
    {
        _go.SetActive(false);
    }

    public void Display()
    {
        _go.SetActive(true);
    }
}
