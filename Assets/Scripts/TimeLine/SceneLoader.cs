using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    float _fadeTiming;
    bool _fadeStart = false;

    public void Load(string sceneName)
    {
        StartCoroutine(WaitFade(sceneName));
    }

    IEnumerator WaitFade(string scene)
    {
        yield return new WaitForSeconds(_fadeTiming);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
