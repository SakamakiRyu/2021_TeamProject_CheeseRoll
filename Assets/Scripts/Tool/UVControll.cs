using UnityEngine;

public class UVControll : MonoBehaviour
{
    [SerializeField]
    private Material _targetMaterial;

    private Vector2 offset;

    private void Awake()
    {
        offset = _targetMaterial.mainTextureOffset;
    }

    public void ChengeUV(float x, float y)
    {
        offset.x = x;
        offset.y = y;
        _targetMaterial.mainTextureOffset = offset;
    }
}