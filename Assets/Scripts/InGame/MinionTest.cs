using UnityEngine;

/// <summary>
/// スマホの上下スワイプ操作で、鉄板の生成位置を操作する
/// </summary>
public class MinionTest : MonoBehaviour
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

    [Header("鉄板生成の下限値( x座標 )")]
    [SerializeField]
    private float _min;

    [Header("鉄板生成の上限値( x座標 )")]
    [SerializeField]
    private float _max;

    [SerializeField]
    private RushCheese _rushCheese;

    /// <summary>前のフレームのx座標を保存しておく変数</summary>
    private float _prevMousePosX;

    /// <summary>画面に触れていたか</summary>
    private bool _isTouch = false;

    private Vector3 _velo;

    private void Awake()
    {
        if (!_targetTransform)
        {
            Debug.LogError("targetTransformを設定してください");
        }
    }

    private void Start()
    {
        _targetTransform.position = _rushCheese.transform.position;
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

        if (Input.GetButtonDown("Fire1"))
        {
            _isTouch = true;
            // Vector3でマウスの位置座標を取得
            pos = Input.mousePosition;
            // Z軸修正
            pos.z = 10f;
            // マウスの位置座標からスクリーン座標に変換する
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(pos);
            // リセット
            _prevMousePosX = screenToWorldPointPosition.x;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _isTouch = false;
        }

        if (_isTouch)
        {
            // Vector3でマウスの位置座標を取得
            pos = Input.mousePosition;
            // Z軸修正
            pos.z = 10f;
            // マウスの位置座標からスクリーン座標に変換する
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(pos);
            // 前フレームとの差分を保存する
            var differenceValue = (screenToWorldPointPosition.x - _prevMousePosX);
            // y座標の保存
            _prevMousePosX = screenToWorldPointPosition.x;

            Debug.Log(differenceValue);
            // ターゲット座標の設定
            if (_rushCheese.Xpos >= _min && _rushCheese.Xpos <= _max)
            {
                _targetTransform.position = new Vector3(_targetTransform.position.x + differenceValue, _rushCheese.transform.position.y, _rushCheese.transform.position.z);
            }
        }

        // 補正(ターゲットのy座標が設定した下限値を下まわった場合は、下限値に修正する)
        if (_rushCheese.Xpos < _min)
        {
            _targetTransform.position = new Vector3(_min, _targetTransform.position.y, _targetTransform.position.z);
            _rushCheese.Xpos = _min;
        }
        // (ターゲットのy座標が設定した上限値を上まわった場合は、上限値に修正する)
        else if (_rushCheese.Xpos > _max)
        {
            _targetTransform.position = new Vector3(_max, _targetTransform.position.y, _targetTransform.position.z);
            _rushCheese.Xpos = _max;
        }

        // ターゲット座標の変更
        _targetTransform.position = new Vector3(_targetTransform.position.x, this.transform.position.y, this.transform.position.z);

        // 生成位置をターゲット座標に追従させる
        _velo += (_targetTransform.position - _rushCheese.transform.position) * _chaseSpeed;
        _velo *= _attenuation;
        _rushCheese.Xpos += _velo.x *= Time.deltaTime;
    }
}
