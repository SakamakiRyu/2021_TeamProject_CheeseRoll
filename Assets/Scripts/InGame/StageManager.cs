using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public enum StageState
    {
        PreGame,
        InGame,
        EndGame,
        GameOver,
    }

    [SerializeField] Transform _endTransform;
    [SerializeField] Transform _startTransform;
    [SerializeField] StageMover _stageMover;
    [SerializeField] RoadMaker _roadMaker;

    //[SerializeField] float _stopDistance = -1.5f;
    [SerializeField] bool _testStop;

    [SerializeField] private CinemachineVirtualCamera _endCamera;

    [SerializeField] GameObject _testResultButton;

    [SerializeField] string[] _foodsList;

    int[] _foodsNums;

    [SerializeField] int _dishes;

    [SerializeField] GameObject[] _foodsObject;
    [Header("評価の大きい順に３つ入れてください")]
    [SerializeField] GameObject[] _dishesObject;

    [SerializeField] ScoreUI _scoreUI;
    [SerializeField] UnityEvent _onGameOver;
    [SerializeField] UnityEvent _onGameClear;
    [SerializeField] CircleFade _fader;

    [Header("クリア時間とスコア(スコアの高い順に入力してください)")]
    [SerializeField] BorderAndScore[] _timeBorderAndScore;

    [Header("具材獲得ボーナス(スコアの高い順に入力してください)")]
    [SerializeField] BorderAndScore[] _bonusScore;

    [Header("完成料理の量に応じたスコア")]
    [SerializeField] float _dish0Score;
    [SerializeField] float _dish1Score;
    [SerializeField] float _dish2Score;
    [SerializeField] float _dish3Score;

    [Header("焦げたorダミー食材獲得時の減少スコア")]
    [SerializeField] float _burntScore;

    [Header("「星」の数の判定(1.5, 2.0, 2.5, 3.0のボーダーライン)(1.5以下は全て星1)")]
    [SerializeField] float _star15Score;
    [SerializeField] float _star20Score;
    [SerializeField] float _star25Score;
    [SerializeField] float _star30Score;


    StageState _state = StageState.PreGame;

    Cheese Cheese => Cheese.Instance;

    public StageState State => _state;
    public void GameOver()
    {
        if (_state == StageState.GameOver) return;
        AudioManager.Instance.PlaySE(AudioManager.SEtype.CheeseMelted);
        _state = StageState.GameOver;
        StopStage();
        _onGameOver.Invoke();
    }

    public void StopStage()
    {
        _stageMover.MoveStop();
        _roadMaker.NowPlay = false;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _fader.FadeOut();
        if (_testStop)
        {
            Vector3 kari = _endTransform.position;
            kari.z = 10;
            _endTransform.position = kari;
        }
        ScoreInit();
        _roadMaker.NowPlay = false;
    }

    private void Update()
    {
        if (_state == StageState.PreGame)
        {
            PreGameUpdate();
        }
        else if (_state == StageState.InGame)
        {
            InGameUpdate();
        }
        else if (_state == StageState.EndGame)
        {
            EndGameUpdate();
        }

    }


    private void PreGameUpdate()
    {
        if (_startTransform.position.z + Cheese.ZPosition < Cheese.transform.position.z)
        {
            StageStart();
            _state = StageState.InGame;
        }
    }

    private void InGameUpdate()
    {
        ScoreManager.Instance.ScoreStructure.Time += Time.deltaTime;
        if (_endTransform.position.z < Cheese.transform.position.z)
        {
            //_stageMover.MoveSpeed = 0;
            //Debug.Log("静止予定" + _cheese.position);

            StageClear();
        }
    }

    private void EndGameUpdate()
    {
    }

    public void StageStart()
    {
        _stageMover.MoveStart();
        _roadMaker.NowPlay = true;
    }

    private void StageClear()
    {
        _state = StageState.EndGame;
        _endCamera.Priority = 3;
        _stageMover.MoveStop();
        _roadMaker.NowPlay = false;
        _onGameClear.Invoke();
        //_testResultButton?.SetActive(true);
    }

    public void ScoreInit()
    {
        _foodsNums = new int[_foodsList.Length];

        //GameObject kariMana = new GameObject("Kari_Manager");
        //kariMana.AddComponent<ScoreManager>();

        ScoreManager.Instance.ScoreStructure = new ScoreManager.Score
            (_foodsList,
            _foodsNums,
            _dishes,
            _scoreUI,
            _foodsObject,
            _dishesObject,
            _timeBorderAndScore,
            _bonusScore,
            burntScore: _burntScore,
            fakeScore: _burntScore,
            new float[] { _dish0Score, _dish1Score, _dish2Score, _dish3Score },
            new float[] { _star15Score, _star20Score, _star25Score, _star30Score },
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        _scoreUI.ScoreUiSetup();

        //if (ScoreManager.Instance && _scoreUI)
        //{
        //    _foodsNums = new int[_foodsList.Length];
        //    ScoreManager.Instance.ScoreStructure = new ScoreManager.Score() { FoodsList = _foodsList, FoodsNums = _foodsNums, ScoreUI = _scoreUI, Dishes = _dishes, FoodsObject = _foodsObject, DishsObject = _dishesObject };
        //    _scoreUI.ScoreUiSetup();
        //}
    }
    public void GateIn()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        //SceneManager.Instance.GoNextScene("Result");
        StartCoroutine(GoResult());
    }

    private IEnumerator GoResult()
    {
        _fader.FadeIn();
        yield return new WaitForSeconds(1.0f);
        SceneManager.Instance.GoNextScene("Result");
    }
}

[System.Serializable]
public struct BorderAndScore
{
    public float border;
    public float score;
}
