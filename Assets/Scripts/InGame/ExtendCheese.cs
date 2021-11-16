using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ExtendCheese : MonoBehaviour
{
    [SerializeField] bool _testSliderV;
    [SerializeField] bool _testSliderH;

    //[SerializeField, Range(1, 2)] float _v = 1f;
    //[SerializeField, Range(1, 2)] float _h = 1f;

    [SerializeField] Transform _rushCheeseExtend;
    Quaternion _origQuaternion;
    Vector3 _origScale;
    Vector3 _cheeseScale;

    private void Start()
    {
        if (_rushCheeseExtend == null)
        {
            _rushCheeseExtend = this.transform;
        }
        _origScale = _rushCheeseExtend.localScale;
        _cheeseScale = _origScale;
        _origQuaternion = _rushCheeseExtend.rotation;
    }

    private void FixedUpdate()
    {
        _rushCheeseExtend.rotation = _origQuaternion;
    }

    //public void TestHorizonX(float x)
    //{
    //    if (_testSliderH)
    //    {
    //        _cheeseScale = _rushCheeseExtend.localScale;
    //        _cheeseScale.x = _origScale.x * x;
    //        _rushCheeseExtend.localScale = _cheeseScale;
    //    }
    //}
    public void TestHorizonY(float y)
    {
        if (_testSliderH)
        {
            _cheeseScale = _rushCheeseExtend.localScale;
            _cheeseScale.y = _origScale.y * y;
            _rushCheeseExtend.localScale = _cheeseScale;
        }
    }
    public void TestVerticalX(float x)
    {
        if (_testSliderV)
        {
            _cheeseScale = _rushCheeseExtend.localScale;
            _cheeseScale.x = _origScale.x * x;
            _rushCheeseExtend.localScale = _cheeseScale;
        }
    }

}
