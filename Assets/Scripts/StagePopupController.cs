using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePopupController : MonoBehaviour
{
    [SerializeField] string[] _texts;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Text _stageText;
    [SerializeField] Image _stageImage;
    Animator _anim;
    bool _isPop;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _isPop = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopUp(0);
        }
    }

    public void PopUp(int id)
    {
        _stageText.text = _texts[id];
        _stageImage.sprite = _sprites[id];
        if (!_isPop)
        {
            _anim.SetTrigger("In");
            _isPop = true;
        }
        else
        {
            _anim.SetTrigger("Out");
            _isPop = false;
        }
    }
}
