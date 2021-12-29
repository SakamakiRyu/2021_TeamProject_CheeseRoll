using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPositioner : MonoBehaviour
{
    [SerializeField] Transform _targetPos;
    [SerializeField] Transform _thisAnchor;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vec = _targetPos.position - _thisAnchor.position;
        this.transform.position += vec;
    }
}