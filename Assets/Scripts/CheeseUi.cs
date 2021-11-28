using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseUi : MonoBehaviour
{
    [SerializeField] Text _cheeseHpText;

    [SerializeField] Image _cheeseHpImage;

    void Update()
    {
        _cheeseHpText.text = $"{(int)(Cheese.Instance?.HP ?? 999)}Åì";
        _cheeseHpImage.fillAmount = (Cheese.Instance?.HP ?? 1.0f) / (Cheese.Instance?.MaxHp ?? 1.0f);
    }
    
}
