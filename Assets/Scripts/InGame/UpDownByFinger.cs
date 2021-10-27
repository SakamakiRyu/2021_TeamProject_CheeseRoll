using UnityEngine;

/// <summary>
/// スマホの上下スワイプ操作で、鉄板の生成位置を操作する
/// </summary>
public class UpDownByFinger : MonoBehaviour
{
    [Header("追従速度")]
    [SerializeField]
    private float _chaseSpeed;

    [Header("減衰力")]
    [SerializeField]
    private float _attenuation;

    [Header("追従するオブジェクトの座標")]
    [SerializeField]
    private Transform _targetTransform;

    [Header("鉄板生成の下限値( y座標 )")]
    [SerializeField]
    private float _min;

    [Header("鉄板生成の上限値( y座標 )")]
    [SerializeField]
    private float _max;

    /// <summary>前のフレームのy座標を保存しておく変数</summary>
    private float _prevMousePosY;

    private Vector3 _velo;

    private void Awake()
    {
        if (!_targetTransform)
        {
            Debug.LogError("targetTransformを設定してください");
        }
    }

    private void Update()
    {
        Control();
    }

    /// <summary>スマホの上下のスワイプ操作にて、生成位置を変更する(↑にスワイプ=上昇)</summary>
    void Control()
    {
        Vector3 pos;
        Vector3 screenToWorldPointPosition;

        // Vector3でマウスの位置座標を取得
        pos = Input.mousePosition;
        // Z軸修正
        pos.z = 10f;
        // マウスの位置座標からスクリーン座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(pos);
        // 前フレームとの差分を保存する
        var differenceValue = (screenToWorldPointPosition.y - _prevMousePosY);

        // ターゲット座標の設定
        if (_targetTransform.position.y >= _min && _targetTransform.position.y <= _max)
        {
            _targetTransform.position = new Vector3(this.transform.position.x, _targetTransform.position.y + differenceValue, this.transform.position.z);
        }

        // 補正(ターゲットのy座標が設定した下限値を下まわった場合は、下限値に修正する)
        if (_targetTransform.position.y < _min)
        {
            _targetTransform.position = new Vector3(_targetTransform.position.x, _min, _targetTransform.position.z);
        }
        // (ターゲットのy座標が設定した上限値を上まわった場合は、上限値に修正する)
        else if (_targetTransform.position.y > _max)
        {
            _targetTransform.position = new Vector3(_targetTransform.position.x, _max, _targetTransform.position.z);
        }

        // y座標の保存
        _prevMousePosY = screenToWorldPointPosition.y;

        // ターゲット座標の変更
        _targetTransform.position = new Vector3(this.transform.position.x, _targetTransform.position.y, this.transform.position.z);

        // 生成位置をターゲット座標に追従させる
        _velo += (_targetTransform.position - this.transform.position) * _chaseSpeed;
        _velo *= _attenuation;
        this.transform.position += _velo *= Time.deltaTime;
    }
}
