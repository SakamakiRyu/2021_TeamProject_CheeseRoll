using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageSelectPlayerCon : MonoBehaviour
{
    [SerializeField]
    public StagePopupController _StagePopupController;

    [SerializeField]
    private CircleFade _fade;

    [SerializeField]
    float _speed;

    [SerializeField]
    public GameObject[] _tips;

    [SerializeField]
    public GameObject _nowLoading;

    [SerializeField]
    public GameObject _loadRoll;

    [SerializeField]
    GameObject[] _stageTarget;
    int _index = 0;

    [SerializeField]
    public GameObject _botan_right;
    public GameObject _botan_left;

    private float _startTime, distance;

    private bool _basebool = true;
    private bool _ismove;

    int _visIndex;


    Vector3 vec = Vector3.zero;
    private float _progress = 0.0f;
    public Vector3 _direction = new Vector3(0f, 0f, 1f);

    private void Awake()
    {
        _fade.FadeOut();
        _index = PlayerPrefs.GetInt("LastStage", 0);
    }
    void Start()
    {
        transform.position = _stageTarget[_index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_basebool)
        {
            // Debug.Log(_index);
            if (!_ismove)
            {
                Debug.Log("not ismove");
                if (Input.GetButtonUp("Fire1"))
                {
                    AudioManager.Instance.PlaySE(AudioManager.SEtype.Button01);

                    if (Input.mousePosition.x > Screen.width / 2 && Input.mousePosition.y > (Screen.height / 3) * 1)
                    {

                        if (_index < _stageTarget.Length - 1)
                        {
                            _index++;
                            StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Right);
                            vec.x = _speed;
                            Debug.Log(_index);

                        }
                        _ismove = true;
                    }
                    else if ((Input.mousePosition.x <= Screen.width / 2 && Input.mousePosition.y > (Screen.height / 3) * 1))
                    {

                        if (_index > 0)
                        {
                            _index--;
                            StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Left);
                            vec.x = -_speed;
                            Debug.Log(_index);

                        }
                        _ismove = true;
                    }
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, _stageTarget[_index].transform.position) > 0.25)
                {
                    //_progress += _speed * Time.deltaTime;
                    transform.position += vec * Time.deltaTime;
                    // Debug.Log(_stageTarget[_index].transform.position);
                }
                else
                {
                    _ismove = false;
                }
            }
        }
        if (_index == 0)
        {
            _botan_left.gameObject.SetActive(false);
        }
        else
        {
            _botan_left.gameObject.SetActive(true);
        }
        if (_index == _stageTarget.Length - 1)
        {
            _botan_right.gameObject.SetActive(false);
        }
        else
        {
            _botan_right.gameObject.SetActive(true);
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        //アニメストップ
        StageSelectPlayerAnimationController.Instance.AnimControll(false);
        var namae = collision.GetComponent<stageID>();
        Debug.Log(namae._id);
        _StagePopupController.PopUp((int)namae._id);
    }
    private void OnTriggerExit(Collider collision)
    {
        //アニメスタート
        StageSelectPlayerAnimationController.Instance.AnimControll(true);
        var namae = collision.GetComponent<stageID>();
        _StagePopupController.PopUp((int)namae._id);
    }
    public void NextSceneAnime()
    {
        Debug.Log("test");
        //todo
        //後ろに下がる
        //フェードのアニメ  
        StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Instage);
    }
    public void NextSene()
    {
        StageSelectPlayerAnimationController.Instance.OnMove(StageSelectPlayerAnimationController.Move.Goback);
        //コルーチンで後ろに行く
        _visIndex = _index + 1;
        Debug.Log("Stage" + _visIndex);
        StartCoroutine(MoveIE());
    }
    public IEnumerator MoveIE()
    {
        float timer = 0;
        _fade.FadeIn();
        Destroy(_botan_left.gameObject);
        Destroy(_botan_right.gameObject);
        while (true)
        {
            transform.position += _direction * _speed * Time.deltaTime;
            timer += Time.deltaTime;
            if (timer > 2)
            {
                //TIPSを表示
                _tips[_index].gameObject.SetActive(true);
                _nowLoading.gameObject.SetActive(true);
                _loadRoll.gameObject.SetActive(true);

                //5秒待つ
                yield return new WaitForSeconds(5);
                PlayerPrefs.SetInt("LastStage", _index);
                SceneManager.Instance.GoNextScene($"Stage{_visIndex}");
                yield break;
            }
            yield return null;
        }    
    }
    public void Ismove()
    {
        _basebool = false;
        Vector3 pos = transform.position;
        
    }
}
