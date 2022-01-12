using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField]
    float vMax;
    [SerializeField]
    float vMin;

    [SerializeField]
    float hMax;
    [SerializeField]
    float hMin;

    [SerializeField]
    GameObject _target;
    
    float _posY;
    float _posX;

    [SerializeField]
    float _swipeSensitivity;
    [SerializeField]
    SwipeType swipeType;

    enum SwipeType
    {
        vertical,
        horizon
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _posY = Input.mousePosition.y;
            _posX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            switch (swipeType)
            {
                case SwipeType.vertical:
                    if (_posY - Input.mousePosition.y > 0.1 || _posY - Input.mousePosition.y < -0.1)
                    {
                        _target.transform.position += new Vector3(0, _swipeSensitivity * (Input.mousePosition.y - _posY), 0);
                        if (_target.transform.position.y > vMax)
                        {
                            _target.transform.position = new Vector3(_target.transform.position.x, vMax * 0.999f, 0);
                        }
                        if (_target.transform.position.y < vMin)
                        {
                            _target.transform.position = new Vector3(_target.transform.position.x, vMin * 0.999f, 0);
                        }
                    }
                    break;
                case SwipeType.horizon:
                    if (_posX - Input.mousePosition.x > 0.1 || _posX - Input.mousePosition.x < -0.1)
                    {
                        _target.transform.position += new Vector3(_swipeSensitivity * (Input.mousePosition.x - _posX), 0, 0);
                        if (_target.transform.position.x > hMax)
                        {
                            _target.transform.position = new Vector3(hMax * 0.999f, _target.transform.position.y, 0);
                        }
                        if (_target.transform.position.x < hMin)
                        {
                            _target.transform.position = new Vector3(hMin * 0.999f, _target.transform.position.y, 0);
                        }
                    }
                    break;
                default:
                    break;
            }
            _posY = Input.mousePosition.y;
            _posX = Input.mousePosition.x;
        }
    }
}
