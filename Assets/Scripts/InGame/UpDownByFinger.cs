using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スマホの上下スワイプ操作で、オブジェクトの座標を操作する
/// </summary>
public class UpDownByFinger : MonoBehaviour
{
    //オブジェクトのy座標の下限値
    [SerializeField]
    private float _min;

    //オブジェクトのy座標の上限値
    [SerializeField]
    private float _max;

    // 位置座標
    private Vector3 _pos;

    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 _screenToWorldPointPosition;

    /// <summary>画面に触っているかのフラグ</summary>
    private bool _isTouch = default;

    private void Update()
    {
        Control();
    }

    /// <summary>スマホの上下のスワイプ操作にて、オブジェクトの座標を変更する(↑にスワイプ=上昇)</summary>
    void Control()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _isTouch = true;
        }

        if (_isTouch)
        {
            // Vector3でマウスの位置座標を取得
            _pos = Input.mousePosition;
            // Z軸修正
            _pos.z = 10f;
            // マウス位置座標からスクリーン座標に変換する
            _screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(_pos);

            // ワールド座標に変換されたマウス座標を代入
            if (_screenToWorldPointPosition.y > _min && _screenToWorldPointPosition.y < _max)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                _screenToWorldPointPosition.y, this.transform.position.z);
                Debug.Log($"{_screenToWorldPointPosition.y}");
            }
        }
    }
}
