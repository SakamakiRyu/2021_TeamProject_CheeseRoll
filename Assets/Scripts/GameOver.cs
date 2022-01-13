using UnityEngine;

/// <summary>
/// ゲームオーバー時の挙動
/// 最終的には、StageManagerで実装する
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
