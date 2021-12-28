using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningZone : MonoBehaviour
{
    [Header("Cheese ‚Ì BurningCheese ‚É‚à“¯‚¶•¶Žš—ñ‚ð")]
    [SerializeField] string _zoneName;

    BurningCheese _cheese;

    public string ZoneName { get => _zoneName;}

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
