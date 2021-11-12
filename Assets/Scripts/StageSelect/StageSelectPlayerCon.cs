using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectPlayerCon : MonoBehaviour
{
    [SerializeField]
    public StagePopupController _StagePopupController;

    [SerializeField]
    float _speed;

    GameObject[] _stageTarget ;
    int _index = 0;

    private float _startTime, distance;

    private bool _ismove;
    Vector3 vec = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _stageTarget = GameObject.FindGameObjectsWithTag("Stage trigger");
        transform.position = _stageTarget[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_index);
        if (!_ismove)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    if (_index < _stageTarget.Length - 1)
                    {
                        StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Right);
                        vec.x = _speed;
                        Debug.Log(_index);
                        _index++;
                    }
                    _ismove = true;
                }
                else
                {
                    if (_index > 0)
                    {
                        StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Left);
                        vec.x = -_speed;
                        Debug.Log(_index);
                        _index--;
                    }
                    _ismove = true;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, _stageTarget[_index].transform.position) > 0.05)
            {
                transform.position += vec;
               // Debug.Log(_stageTarget[_index].transform.position);
            }
            else
            {
                _ismove = false;
            }
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
