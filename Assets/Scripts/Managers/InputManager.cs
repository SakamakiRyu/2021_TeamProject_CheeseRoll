using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーからの入力を統括する
/// </summary>
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        MakeSingle();
    }

    private void MakeSingle()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// マウスの位置を返す
    /// </summary>
    /// <returns></returns>
    public Vector2 MousePos()
    {
        return Input.mousePosition;
    }
}
