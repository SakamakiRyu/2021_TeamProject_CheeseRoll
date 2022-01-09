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
    }

    public static EffectManager Instance { get; private set; }

    [SerializeField]
    private CinemachineImpulseSource _ImpluseSource;

    [Header("EffectTypeのenumと同じ順番に入れてください")]
    [SerializeField]
    private GameObject[] _effectPrefabs;
    

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
        Vector3 pos = localPosition ?? Vector3.zero;
        GameObject effect = Instantiate(_effectPrefabs[(int)type]);
        effect.transform.parent = parent;
        effect.transform.localPosition = pos;
        return effect;
    }
}
