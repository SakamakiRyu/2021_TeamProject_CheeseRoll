using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickJump : MonoBehaviour
{
    [SerializeField] float _jumpPower; 

    Vector2 _touchStartPos;
    Vector2 _tochEndPos;

    [SerializeField] Vector2 _flickMinRange = new Vector2(30.0f, 30.0f);

    int _noneCountMax = 2;
    int _noneCountNow;

    enum FlickState
    {
        NONE,
        TAP,
        UP,
        DOWN,
        RIGHT,
        LEFT
    };
    FlickState _nowTouchState = FlickState.NONE;


    void Update()
    {

        GetFlickDirection();
        switch (_nowTouchState)
        {
            case FlickState.NONE:
                break;
            case FlickState.TAP:
                break;
            case FlickState.UP:
                var rb = gameObject.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, _jumpPower, 0), ForceMode.Impulse);
                break;
            case FlickState.DOWN:
                break;
            case FlickState.RIGHT:
                break;
            case FlickState.LEFT:
                break;
            default:
                break;
        }
    }
    void GetFlickDirection()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchStartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _tochEndPos = Input.mousePosition;
                Flick();
            }
            else if (_nowTouchState != FlickState.NONE)
            {
                ResetParametor();
            }


        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    _touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _tochEndPos = touch.position;
                    Flick();
                }
                else if (_nowTouchState != FlickState.NONE)
                {
                    ResetParametor();
                }
            }

        }
    }
    void Flick()
    {
        Vector2 w = new Vector2((new Vector3(_tochEndPos.x, 0, 0) - new Vector3(_touchStartPos.x, 0, 0)).magnitude, (new Vector3(0, _tochEndPos.y) - new Vector3(0, _touchStartPos.y)).magnitude);
        if (w.x <= _flickMinRange.x&&w.y <= _flickMinRange.y)
        {
            _nowTouchState = FlickState.TAP;
        }else if(w.x > w.y)
        {
            float x = Mathf.Sign(_tochEndPos.x - _touchStartPos.x);
            if (x > 0) _nowTouchState = FlickState.RIGHT;
            else if (x < 0) _nowTouchState = FlickState.LEFT;
        }
        else
        {
            float y = Mathf.Sign(_tochEndPos.y - _touchStartPos.y);
            if (y > 0) _nowTouchState = FlickState.UP;
            else if (y < 0) _nowTouchState = FlickState.DOWN;
        }
    }

    private void ResetParametor()
    {
        _noneCountNow++;
        if (_noneCountNow >= _noneCountMax)
        {
            _noneCountNow = 0;
            _nowTouchState = FlickState.NONE;
        }
    }
}
