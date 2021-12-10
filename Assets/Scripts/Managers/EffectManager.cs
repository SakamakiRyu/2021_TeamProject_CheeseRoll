using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// �G�t�F�N�g�Ǘ��N���X
/// 
/// �J�����V�F�C�N��vcam��ImpluseListner���A�^�b�`����B
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
    /// �J�����V�F�C�N������
    /// </summary>
    public void PlayCameraShake()
    {
        if (_ImpluseSource)
        {
            _ImpluseSource?.GenerateImpulse();
        }
    }
}
