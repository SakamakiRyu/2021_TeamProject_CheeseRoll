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

    [Header("変化量の倍率")]
    [SerializeField]
    private float _variation = 1;

    /// <summary>前のフレームのy座標を保存しておく</summary>
    private float _prevMousePosY;

    /// <summary>画面に触っているかのフラグ</summary>
    private bool _isTouched = default;

    private void Update()
    {
        Control();
    }

    /// <summary>スマホの上下のスワイプ操作にて、オブジェクトの座標を変更する(↑にスワイプ=上昇)</summary>
    void Control()
    {
        Vector3 pos;
        Vector3 screenToWorldPointPosition;

        if (Input.GetButtonDown("Fire1"))
        {
            _isTouched = true;
            // Vector3でマウスの位置座標を取得
            pos = Input.mousePosition;
            // Z軸修正
            pos.z = 10f;
            // マウス位置座標からスクリーン座標に変換する
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(pos);
            // タッチしたフレーム時の座標を保存
            _prevMousePosY = screenToWorldPointPosition.y;
        }

        // 画面に触れていない場合は何もしない
        if (!_isTouched) return;

        if (Input.GetButtonUp("Fire1"))
        {
            _isTouched = false;
            return;
        }

        if (_isTouched)
        {
            // Vector3でマウスの位置座標を取得
            pos = Input.mousePosition;
            // Z軸修正
            pos.z = 10f;
            // マウス位置座標からスクリーン座標に変換する
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(pos);
            // 前フレームとの差分を保存する
            var difference = (screenToWorldPointPosition.y - _prevMousePosY) * _variation;
            if (this.transform.position.y >= _min && this.transform.position.y <= _max)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + difference, this.transform.position.z);
            }

            // 補正
            if (this.transform.position.y < _min )
            {
                this.transform.position = new Vector3( this.transform.position.x,_min,this.transform.position.z);
            }
            if (this.transform.position.y > _max)
            {
                this.transform.position = new Vector3(this.transform.position.x, _max, this.transform.position.z);
            }
            // 前フレームの座標を保存
            _prevMousePosY = screenToWorldPointPosition.y;
        }
    }
}
