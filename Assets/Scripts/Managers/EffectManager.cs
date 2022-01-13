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
        HitObstacle,
        Death01,
        Death02,
        Goal,
        Smoke
    }

    public static EffectManager Instance { get; private set; }

    [SerializeField]
    private CinemachineImpulseSource _ImpluseSource;

    [Header("EffectType��enum�Ɠ������Ԃɓ���Ă�������")]
    [SerializeField]
    private GameObject[] _effectPrefabs;
    private int[] _effectVibrationLength = new int[] { 50, 50, 100, 0, 100, 250, 0};
    private float[] _effectCameraShakePower = new float[] { 0, 0, 0.2f, 0, 0.2f, 0.1f, 0};
    

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
        int index = (int)type;
        //�o�C�u���[�V����
        if (_effectVibrationLength[index] != 0)
        {
            VibrationManager.Vibration(_effectVibrationLength[index]);
        }
        //�J�����V�F�C�N
        if (_effectCameraShakePower[index] != 0f)
        {
            float a = _effectCameraShakePower[index];
            PlayCameraShake(new Vector3(a, a, a));
        }
        //�G�t�F�N�g����
        Vector3 pos = localPosition ?? Vector3.zero;
        GameObject effect = Instantiate(_effectPrefabs[index]);
        effect.transform.parent = parent;
        effect.transform.localPosition = pos;
        return effect;
    }
}
