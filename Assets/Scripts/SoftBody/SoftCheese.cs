using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftCheese : MonoBehaviour
{
    /*
     *        3
     *    2       4
     *         
     *  1     r     5
     *  
     *    6       7
     *        8
     */

    [Header("Material")]
    [SerializeField] PhysicMaterial _physicMaterial;
    [Header("Bones")]
    [SerializeField] GameObject _root = null;
    [SerializeField] GameObject _b1 = null;
    [SerializeField] GameObject _b2 = null;
    [SerializeField] GameObject _b3 = null;
    [SerializeField] GameObject _b4 = null;
    [SerializeField] GameObject _b5 = null;
    [SerializeField] GameObject _b6 = null;
    [SerializeField] GameObject _b7 = null;
    [SerializeField] GameObject _b8 = null;
    [Header("Spring Joint Settings")]
    [Tooltip("Strength of spring")]
    [SerializeField] float _spring = 3000.0f;
    [Tooltip("Higher the value the faster the spring oscillation stops")]
    [SerializeField] float _damper = 10.0f;
    [Header("Other Settings")]
    [SerializeField] Softbody.ColliderShape _shape = Softbody.ColliderShape.Box;
    [SerializeField] float _colliderSize = 0.002f;
    [SerializeField] float _rigidbodyMass = 1f;

    private void Start()
    {
        Softbody.Init(_shape, _colliderSize, _rigidbodyMass, _spring, _damper, RigidbodyConstraints.FreezeRotation, _physicMaterial);

        Rigidbody root = Softbody.AddCollider(ref _root, Softbody.ColliderShape.Sphere, 0.1f, 1.0f);
        //root.constraints = RigidbodyConstraints.None;
        //root.isKinematic = true;
        root.interpolation = RigidbodyInterpolation.Interpolate;
        //root.gameObject.layer = LayerMask.NameToLayer("CheeseBody");
        root.freezeRotation = false;
        Softbody.AddCollider(ref _b1);
        Softbody.AddCollider(ref _b2);
        Softbody.AddCollider(ref _b3);
        Softbody.AddCollider(ref _b4);
        Softbody.AddCollider(ref _b5);
        Softbody.AddCollider(ref _b6);
        Softbody.AddCollider(ref _b7);
        Softbody.AddCollider(ref _b8);

        //Softbody.AddSpring(ref _root, ref _bodyRoot);
        Softbody.AddSpring(ref _b1, ref _root);
        Softbody.AddSpring(ref _b2, ref _root);
        Softbody.AddSpring(ref _b3, ref _root);
        Softbody.AddSpring(ref _b4, ref _root);
        Softbody.AddSpring(ref _b5, ref _root);
        Softbody.AddSpring(ref _b6, ref _root);
        Softbody.AddSpring(ref _b7, ref _root);
        Softbody.AddSpring(ref _b8, ref _root);

        Softbody.AddSpring(ref _b1, ref _b2);
        Softbody.AddSpring(ref _b2, ref _b3);
        Softbody.AddSpring(ref _b3, ref _b4);
        Softbody.AddSpring(ref _b4, ref _b5);
        Softbody.AddSpring(ref _b5, ref _b6);
        Softbody.AddSpring(ref _b6, ref _b7);
        Softbody.AddSpring(ref _b7, ref _b8);
        Softbody.AddSpring(ref _b8, ref _b1);
    }
}
