using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectPlayerCon : MonoBehaviour
{
    [SerializeField]
    public StagePopupController _StagePopupController;

    GameObject[] _stageTarget ;
    int _index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _stageTarget = GameObject.FindGameObjectsWithTag("Stage trigger");
        transform.position = _stageTarget[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _index++;
            if (_index >= _stageTarget.Length)
            {
                Debug.Log(_index);
                _index = _stageTarget.Length -1;
            }
            transform.position = _stageTarget[_index].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _index--;
            if (_index <= 0)
            {
                Debug.Log(_index);
                _index = 0;
            }
            transform.position = _stageTarget[_index].transform.position;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Stage trigger"))
        {
            
            var namae = collision.GetComponent<stageID>();
            Debug.Log(namae._id);
            _StagePopupController.PopUp((int)namae._id);
            Debug.Log("in");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Stage trigger"))
        {
            var namae = collision.GetComponent<stageID>();
            _StagePopupController.PopUp((int)namae._id);
            Debug.Log("out");
        }
    }
}
