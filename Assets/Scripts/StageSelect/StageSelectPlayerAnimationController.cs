using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectPlayerAnimationController : MonoBehaviour
{
    public static StageSelectPlayerAnimationController Instance;

    [SerializeField]
    Animator _animator = null;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 進行方向
    /// </summary>
    public enum Move
    {
        Right,
        Left
    }

    /// <summary>
    /// 進行方向を受け取って、アニメーターに渡す
    /// </summary>
    /// <param name="nextPosition">進行方向</param>
    public void OnMove(Move nextPosition)
    {
        switch (nextPosition)
        {
            case Move.Right:
                _animator.SetTrigger("Right");

                break;
            case Move.Left:
                _animator.SetTrigger("Left");
                break;
            default:
                break;
        }

    }

    public void AnimControll(bool param)
    {
        if (param)
            _animator.SetBool("Animation", true);
        else
            _animator.SetBool("Animation", false);
    }
}
