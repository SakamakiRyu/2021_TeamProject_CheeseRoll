using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
    private Vector3 _pos, currentPos;
    [SerializeField]
    GameObject _panelPages;
    [SerializeField]
    float _sensitivity = 1; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            Vector3 diffDistance = currentPos - _pos;
            diffDistance *= _sensitivity;
            _panelPages.transform.position += new Vector3(diffDistance.x, 0);
            _pos = Input.mousePosition;
        }
    }
}
