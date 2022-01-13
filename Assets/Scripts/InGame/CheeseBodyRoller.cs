using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBodyRoller : MonoBehaviour
{
    [SerializeField]
    Transform body;


    private void LateUpdate()
    {
        this.transform.rotation = Quaternion.identity;
        body.transform.rotation = transform.parent.rotation;
    }
}
