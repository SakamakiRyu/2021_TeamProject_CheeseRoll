using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseUi : MonoBehaviour
{
    [SerializeField] Text _cheeseHpText;

    [SerializeField] Image _cheeseHpImage;

    [SerializeField] Cheese _cheese;
    void Update()
    {
        _cheeseHpText.text = $"{_cheese.Hp}Åì";
        _cheeseHpImage.fillAmount = _cheese.Hp/100;

    }
    
}
