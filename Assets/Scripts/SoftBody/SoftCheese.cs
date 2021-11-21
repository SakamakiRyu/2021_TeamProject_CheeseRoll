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
     *    8       6
     *        7
     */

    [Header("Material")]
    [SerializeField] PhysicMaterial _physicMaterial;
    [Header("Bones")]
    [SerializeField] GameObject _rootRoot = null;
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
    [SerializeField] float _rootColliderSize = 0.002f;
    [SerializeField] float _rootRigidbodyMass = 1f;

    Rigidbody _rootRigidbody;
    Rigidbody[] rigidbodies = new Rigidbody[8];
    Quaternion?[] rotations = new Quaternion?[8];
    

    private void Start()
    {
        //Softbody.Init(_shape, _colliderSize, _rigidbodyMass, _spring, _damper, RigidbodyConstraints.FreezeRotation, _physicMaterial);
        Softbody.Init(_shape, _colliderSize, _rigidbodyMass, _spring, _damper, RigidbodyConstraints.None, _physicMaterial);

        _rootRigidbody = Softbody.AddCollider(ref _root, Softbody.ColliderShape.Sphere, _rootColliderSize, _rootRigidbodyMass);
        //_rigidbody.constraints = RigidbodyConstraints.None;
        //_rigidbody.isKinematic = true;
        //_rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        //_rigidbody.gameObject.layer = LayerMask.NameToLayer("CheeseBody");
        //_rootRigidbody.freezeRotation = false;


        rigidbodies[0] = Softbody.AddCollider(ref _b1);
        rigidbodies[1] = Softbody.AddCollider(ref _b2);
        rigidbodies[2] = Softbody.AddCollider(ref _b3);
        rigidbodies[3] = Softbody.AddCollider(ref _b4);
        rigidbodies[4] = Softbody.AddCollider(ref _b5);
        rigidbodies[5] = Softbody.AddCollider(ref _b6);
        rigidbodies[6] = Softbody.AddCollider(ref _b7);
        rigidbodies[7] = Softbody.AddCollider(ref _b8);

        for (int i = 0; i < 8; i++)
        {
            if (rigidbodies[i].transform.localRotation != Quaternion.identity)
            {
                rotations[i] = rigidbodies[i].transform.localRotation;
            }
            else
            {
                rotations[i] = null;
            }
        }

        Softbody.AddSpring(ref _root, ref _rootRoot);
        Softbody.AddSpring(ref _b1, ref _root);
        Softbody.AddSpring(ref _b2, ref _root);
        Softbody.AddSpring(ref _b3, ref _root);
        Softbody.AddSpring(ref _b4, ref _root);
        Softbody.AddSpring(ref _b5, ref _root);
        Softbody.AddSpring(ref _b6, ref _root);
        Softbody.AddSpring(ref _b7, ref _root);
        Softbody.AddSpring(ref _b8, ref _root);

        //Softbody.AddSpring(ref _b1, ref _b3);
        //Softbody.AddSpring(ref _b3, ref _b5);
        //Softbody.AddSpring(ref _b5, ref _b7);
        //Softbody.AddSpring(ref _b7, ref _b1);

        //Softbody.AddSpring(ref _b2, ref _b4);
        //Softbody.AddSpring(ref _b4, ref _b6);
        //Softbody.AddSpring(ref _b6, ref _b8);
        //Softbody.AddSpring(ref _b8, ref _b2);

        Softbody.AddSpring(ref _b1, ref _b2);
        Softbody.AddSpring(ref _b2, ref _b3);
        Softbody.AddSpring(ref _b3, ref _b4);
        Softbody.AddSpring(ref _b4, ref _b5);
        Softbody.AddSpring(ref _b5, ref _b6);
        Softbody.AddSpring(ref _b6, ref _b7);
        Softbody.AddSpring(ref _b7, ref _b8);
        Softbody.AddSpring(ref _b8, ref _b1);
    }

    private void FixedUpdate()
    {
        //_rootRigidbody.AddTorque(new Vector3(10,0,0));

        _rootRigidbody.angularVelocity = Vector3.zero;
        _rootRigidbody.transform.localRotation = Quaternion.identity;
        //_rootRigidbody.transform.localPosition = Vector3.zero;

        for (int i = 0; i < 8; i++)
        {
            rigidbodies[i].angularVelocity = Vector3.zero;
            if (rotations[i] is null)
            {
                rigidbodies[i].transform.localRotation = Quaternion.identity;
            }
            else
            {
                rigidbodies[i].transform.localRotation = (Quaternion)rotations[i];
            }
        }
    }
}
