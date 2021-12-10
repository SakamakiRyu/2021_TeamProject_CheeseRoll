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
    [SerializeField] GameObject[] _dishesObject;

    [SerializeField] ScoreUI _scoreUI;
    [SerializeField] UnityEvent _onGameOver;
    [SerializeField] UnityEvent _onGameClear;


    StageState _state = StageState.PreGame;

    Cheese Cheese => Cheese.Instance;

    public StageState State => _state;
    public void GameOver()
    {
        _state = StageState.GameOver;
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
        if (_endTransform.position.z < Cheese.transform.position.z)
        {
            //_stageMover.MoveSpeed = 0;
            //Debug.Log("静止予定" + _cheese.position);

            StageClear();
            _state = StageState.EndGame;
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
        _endCamera.Priority = 3;
        _stageMover.MoveStop();
        _testResultButton.SetActive(true);
        _roadMaker.NowPlay = false;
        _onGameClear.Invoke();
    }

    public void ScoreInit()
    {
        _foodsNums = new int[_foodsList.Length];

        GameObject kariMana = new GameObject("Kari_Manager");
        kariMana.AddComponent<ScoreManager>();

        ScoreManager.Instance.ScoreStructure = new ScoreManager.Score() { FoodsList = _foodsList, FoodsNums = _foodsNums, ScoreUI = _scoreUI, Dishes = _dishes, FoodsObject = _foodsObject, DishsObject = _dishesObject };

        //_scoreUI.ScoreUiSetup();

        //if (ScoreManager.Instance && _scoreUI)
        //{
        //    _foodsNums = new int[_foodsList.Length];
        //    ScoreManager.Instance.ScoreStructure = new ScoreManager.Score() { FoodsList = _foodsList, FoodsNums = _foodsNums, ScoreUI = _scoreUI, Dishes = _dishes, FoodsObject = _foodsObject, DishsObject = _dishesObject };
        //    _scoreUI.ScoreUiSetup();
        //}
    }
    public void GateIn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        //SceneManager.Instance.GoNextScene("Result");
    }
}
