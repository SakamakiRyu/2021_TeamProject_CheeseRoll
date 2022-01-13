using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePopupController : MonoBehaviour
{
    [SerializeField] Sprite[] _PressedSprites;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Button _stageButton;
    Animator _anim;
    bool _isPop;

    SpriteState _state = new SpriteState();

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
        _state = _stageButton.spriteState;
    }

    public void PopUp(int id)
    {
        _state = _stageButton.spriteState;
        _stageButton.image.sprite = _sprites[id];
        _state.pressedSprite = _PressedSprites[id];
        _stageButton.spriteState = _state;
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
