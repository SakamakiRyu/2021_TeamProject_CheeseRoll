using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderWithButton : MonoBehaviour
{
    [SerializeField]
    float _fadeTiming;

    public void Load(string sceneName)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySE(AudioManager.SEtype.CancelButton);
        }
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.interactable = false;
        StartCoroutine(WaitFade(sceneName));
    }

    IEnumerator WaitFade(string scene)
    {
        yield return new WaitForSeconds(_fadeTiming);
        if (scene == "Retry")
        {
            scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        }
        SceneManager.Instance.GoNextScene(scene);

    }
}
