using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushNextScene : MonoBehaviour
{
    [SerializeField] string _nextSceneName;

    /// <summary> _nextSceneName にシーン遷移する </summary>
    public void GoNextScene()
    {
        SceneManager.Instance.GoNextScene(_nextSceneName);
    }
}
