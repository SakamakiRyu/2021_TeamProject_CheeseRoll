using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スマホの上下スワイプ操作で、オブジェクトの座標を操作する
/// </summary>
public class UpDownByFinger : MonoBehaviour
{
    // 比較結果を受け取る時に使う
    private readonly string Down = "Down";
    private readonly string Up = "Up";
    private readonly string Preservation = "Preservation";

    //オブジェクトのy座標の下限値
    [SerializeField]
    private float _min;

    //オブジェクトのy座標の上限値
    [SerializeField]
    private float _max;
    
    [Header("可変値")]
    [SerializeField]
    private float _chengeValue = default;

    /// <summary>位置情報</summary>
    private Vector3 _pos;

    /// <summary>スクリーン座標をワールド座標に変換した位置座標</summary>
    private Vector3 _screenToWorldPointPosition;

    /// <summary>前フレームの入力を保存しておく変数</summary>
    private float _prevPosY;

    /// <summary>画面に触っているかのフラグ</summary>
    private bool _isTouch = default;

    private void Update()
    {
        Control();
    }

    /// <summary>スマホの上下のスワイプ操作にて、オブジェクトの座標を変更する(↑にスワイプ=上昇)</summary>
    void Control()
    {
        // Vector3でマウスの位置座標を取得
        _pos = Input.mousePosition;
        // Z軸修正
        _pos.z = 10f;
        // マウス位置座標からスクリーン座標に変換する
        var _currentPosY = Camera.main.ScreenToWorldPoint(_pos).y;

        if (Input.GetButtonDown("Fire1"))
        {
            _isTouch = true;
            _prevPosY = _pos.y;
        }

        // 入力が無かった場合は、無駄な処理(入力された時に行う処理)しない
        if (!_isTouch) return;

        if (Input.GetButtonUp("Fire1"))
        {
            _isTouch = false;
        }

        if (_isTouch)
        {
            if (this.transform.position.y >= _min && this.transform.position.y <= _max)
            {
                var result = IsDirectionUp(_prevPosY, _currentPosY);

                if (result.Equals(Down))
                {
                    Debug.Log(Down);
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                        this.gameObject.transform.position.y - _chengeValue, this.gameObject.transform.position.z);

                    // 補正
                    if (this.gameObject.transform.position.y <= _min)
                    {
                        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                        _min, this.gameObject.transform.position.z);
                    }
                }
                else if (result.Equals(Up))
                {
                    Debug.Log(Up);
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                        this.gameObject.transform.position.y + _chengeValue, this.gameObject.transform.position.z);

                    // 補正
                    if (this.gameObject.transform.position.y >= _max)
                    {
                        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                        _max, this.gameObject.transform.position.z);
                    }
                }
                else
                {
                    Debug.Log(Preservation);
                }
            }

            //// ワールド座標に変換されたマウス座標を代入
            //if (_screenToWorldPointPosition.y > _min && _screenToWorldPointPosition.y < _max)
            //{
            //    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
            //    _screenToWorldPointPosition.y, this.transform.position.z);
            //    Debug.Log($"{_screenToWorldPointPosition.y}");
            //}
        }
        _prevPosY = _currentPosY;
    }

    // 関数名は分かりやすい物に変更

    /// <summary>前フレームの座標と現在の座標を比較して、スワイプの方向を調べる </summary>
    /// <returns>true == up,false == down</returns>
    string IsDirectionUp(float prevY, float currentY)
    {
        prevY = prevY * 100;
        currentY = currentY * 100;

        prevY = Mathf.Floor(prevY);
        currentY = Mathf.Floor(currentY);

        if (prevY > currentY)
        {
            return Down;
        }
        else if (prevY < currentY)
        {
            return Up;
        }
        else
        {
            return Preservation;
        }
    }
}
