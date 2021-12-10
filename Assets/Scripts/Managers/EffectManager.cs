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
    public static EffectManager Instance { get; private set; }

    [SerializeField]
    private CinemachineImpulseSource _ImpluseSource;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// カメラシェイクをする
    /// </summary>
    public void PlayCameraShake()
    {
        if (_ImpluseSource)
        {
            _ImpluseSource?.GenerateImpulse();
        }
    }
}
