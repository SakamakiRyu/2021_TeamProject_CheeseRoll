using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCtrl : MonoBehaviour
{
    [SerializeField]
    float _speed = 1;
    [SerializeField]
    UVControll _uvControll;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        _uvControll.TargetMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        _uvControll.MoveUV(_speed * Time.deltaTime, 0);
    }
}
