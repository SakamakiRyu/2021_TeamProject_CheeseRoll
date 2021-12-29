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
    public Vector3 _direction = new Vector3(0f, 0f, 1f);

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
                if (Input.mousePosition.x > Screen.width / 2 && Input.mousePosition.y > (Screen.height / 3) * 1)
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
                else if ((Input.mousePosition.x <= Screen.width / 2 && Input.mousePosition.y > (Screen.height / 3) * 1))
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
    public void OnTriggerEnter(Collider collision)
    {
        //アニメストップ
        StageSelectPlayerAnimationController.Instance.AnimControll(false);
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
        //アニメスタート
        StageSelectPlayerAnimationController.Instance.AnimControll(true);
        if (collision.CompareTag("Stage trigger"))
        {
            var namae = collision.GetComponent<stageID>();
            _StagePopupController.PopUp((int)namae._id);
            Debug.Log("out");
        }
    }
    public void NextSceneAnime()
    {
        //todo
        //後ろに下がる
        //フェードのアニメ
        StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Instage);
    }
    public void NextSene()
    {
        StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Goback);
        //コルーチンで後ろに行く
        int visIndex = _index + 1;
        Debug.Log("Stage" + visIndex);
        StartCoroutine("MoveIE");

        //UnityEngine.SceneManagement.SceneManager.LoadScene("Stage"+visIndex); 
    }
    public IEnumerator MoveIE()
    {   
        while (true)
        {
            float step = _speed * Time.deltaTime;
            transform.position += _direction * _speed;
            yield return null;
        }
    }
}
