using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBodyRoller : MonoBehaviour
{
    public Quaternion BodyLookAt { get; set; } = Quaternion.identity;

    Transform body;

    private void Awake()
    {
        body = transform.GetChild(0);
    }

    private void LateUpdate()
    {
        this.transform.rotation = BodyLookAt;
        body.transform.rotation = transform.parent.rotation;
    }
}
