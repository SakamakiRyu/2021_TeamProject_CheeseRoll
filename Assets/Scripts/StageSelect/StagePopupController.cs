using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePopupController : MonoBehaviour
{
    [SerializeField] Sprite[] _PressedSprites;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Button _stageButton;
    [SerializeField] Image _dishFoodImage;
    [SerializeField] StarFiller _starFiller;
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
        _dishFoodImage.sprite = HighScoreManager.Incetance.HighScoreStructurs[id].GetDishPic();
        _starFiller.ResetFill(3);
        switch (HighScoreManager.Incetance.HighScoreStructurs[id].GetHighScore())
        {
            case 2:
                _starFiller.StarFill(1,1000.0f);
                break;

            case 3:
                _starFiller.StarFill(1.5f, 1000.0f);
                break;

            case 4:
                _starFiller.StarFill(2, 1000.0f);
                break;

            case 5:
                _starFiller.StarFill(2.5f, 1000.0f);
                break;

            case 6:
                _starFiller.StarFill(3, 1000.0f);
                break;

            default:
                break;
        }
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
