using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningZone : MonoBehaviour
{
    [Header("Cheese �� BurningCheese �ɂ������������")]
    [SerializeField] string _zoneName;

    [Header("False �Ȃ�Q�[�����ɕ\������Ȃ��Ȃ�܂�")]
    [SerializeField] bool _isTest = true;

    BurningCheese _cheese;

    public string ZoneName { get => _zoneName;}

    private void Awake()
    {
        if (_isTest == false)
        {
            Destroy(GetComponent<Renderer>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_cheese != null) { return; }

        if (other.transform.tag == "Player")
        {
            _cheese = other.GetComponent<BurningCheese>();
            //_cheese.NowIsZone = true;

            //_cheese.EnterZone(_zoneName);
            _cheese.StartBurn(_zoneName, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_cheese == null) { return; }

        //_cheese.NowIsZone = false;
        //_cheese.ExitZone();
        //_cheese.ExitZone(_zoneName);
        _cheese.EndBurn(_zoneName);

        _cheese = null;
    }


}
