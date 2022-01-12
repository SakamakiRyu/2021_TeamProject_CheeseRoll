using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// エフェクト管理クラス
/// 
/// カメラシェイクはvcamにImpluseListnerをアタッチする。
/// </summary>
//[RequireComponent(typeof(CinemachineImpulseSource))]
public class EffectManager : MonoBehaviour
{
    public enum EffectType
    {
        GetItem,
        Cure,
        HitObstacle,
        Death01,
        Death02,
    }

    public static EffectManager Instance { get; private set; }

    [SerializeField]
    private CinemachineImpulseSource _ImpluseSource;

    [Header("EffectTypeのenumと同じ順番に入れてください")]
    [SerializeField]
    private GameObject[] _effectPrefabs;
    private int[] _effectVibrationLength = new int[] { 25, 25, 100, 0, 100};
    private float[] _effectCameraShakePower = new float[] { 0, 0, 0.2f, 0, 0.2f};
    

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// カメラシェイクをする
    /// </summary>
    public void PlayCameraShake(float size)
    {
        if (_ImpluseSource)
        {
            _ImpluseSource?.GenerateImpulse(size);
        }
    }

    /// <summary>
    /// カメラシェイクをする
    /// </summary>
    public void PlayCameraShake(Vector3 velocity)
    {
        if (_ImpluseSource)
        {
            _ImpluseSource?.GenerateImpulse(velocity);
        }
    }

    public GameObject PlayEffect(EffectType type, Vector3? localPosition = null, Transform parent = null)
    {
        int index = (int)type;
        //バイブレーション
        if (_effectVibrationLength[index] != 0)
        {
            VibrationManager.Vibration(_effectVibrationLength[index]);
        }
        //カメラシェイク
        if (_effectCameraShakePower[index] != 0f)
        {
            float a = _effectCameraShakePower[index];
            PlayCameraShake(new Vector3(a, a, a));
        }
        //エフェクト生成
        Vector3 pos = localPosition ?? Vector3.zero;
        GameObject effect = Instantiate(_effectPrefabs[index]);
        effect.transform.parent = parent;
        effect.transform.localPosition = pos;
        return effect;
    }
}
