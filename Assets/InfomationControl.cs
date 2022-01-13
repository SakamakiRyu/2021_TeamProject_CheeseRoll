using UnityEngine;

public class InfomationControl : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    void Update()
    {
        if (text)
        {
            text.SetActive(UpDownByFinger.Instance.IsReverse);
        }
    }
}
