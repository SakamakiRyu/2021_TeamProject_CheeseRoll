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
    public enum EffectType
    {
        GetItem,
        Cure,
    }

    public static EffectManager Instance { get; private set; }

    [SerializeField]
    private CinemachineImpulseSource _ImpluseSource;

    [Header("EffectType��enum�Ɠ������Ԃɓ���Ă�������")]
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
    /// �J�����V�F�C�N������
    /// </summary>
    public void PlayCameraShake(float size)
    {
        if (_ImpluseSource)
        {
            _ImpluseSource?.GenerateImpulse(size);
        }
    }

    /// <summary>
    /// �J�����V�F�C�N������
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
