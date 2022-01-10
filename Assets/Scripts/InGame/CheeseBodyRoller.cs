using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBodyRoller : MonoBehaviour
{
    Transform body;

    private void Awake()
    {
        body = transform.GetChild(0);
    }

    private void LateUpdate()
    {
        this.transform.rotation = Quaternion.identity;
        body.transform.rotation = transform.parent.rotation;
    }
}
