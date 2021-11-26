using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public enum StageState
    {
        PreGame,
        InGame,
        EndGame,
    }

    [SerializeField] Transform _endTransform;
    [SerializeField] Transform _startTransform;
    [SerializeField] StageMover _stageMover;
    [SerializeField] RoadMaker _roadMaker;
    [SerializeField] Cheese _cheese;
    //[SerializeField] float _stopDistance = -1.5f;
    [SerializeField] bool _testStop;

    [SerializeField] GameObject _testResultButton;

    [SerializeField] string[] _foodsList;

    int[] _foodsNums;

    [SerializeField] int _dishes;

    [SerializeField] GameObject[] _foodsObject;
    [SerializeField] GameObject[] _dishesObject;

    [SerializeField] ScoreUI _scoreUI;


    StageState _state = StageState.PreGame;

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
        if (_startTransform.position.z + _cheese.ZPosition < _cheese.transform.position.z)
        {
            StageStart();
            _state = StageState.InGame;
        }
    }

    private void InGameUpdate()
    {
        if (_endTransform.position.z < _cheese.transform.position.z)
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

    private void StageStart()
    {
        _stageMover.MoveStart();
        _roadMaker.NowPlay = true;
    }

    private void StageClear()
    {
        _stageMover.MoveStop();
        _testResultButton.SetActive(true);
        _roadMaker.NowPlay = false;
    }

    public void ScoreInit()
    {
<<<<<<< HEAD
        _foodsNums = new int[_foodsList.Length];

        GameObject kariMana = new GameObject("Kari_Manager");
        kariMana.AddComponent<ScoreManager>();

        ScoreManager.Instance.ScoreStructure = new ScoreManager.Score() { FoodsList = _foodsList, FoodsNums = _foodsNums, ScoreUI = _scoreUI, Dishes = _dishes, FoodsObject = _foodsObject, DishsObject = _dishesObject };

        //_scoreUI.ScoreUiSetup();
=======
        if (ScoreManager.Instance && _scoreUI)
        {
            _foodsNums = new int[_foodsList.Length];
            ScoreManager.Instance.ScoreStructure = new ScoreManager.Score() { FoodsList = _foodsList, FoodsNums = _foodsNums, ScoreUI = _scoreUI, Dishes = _dishes, FoodsObject = _foodsObject, DishsObject = _dishesObject };
            _scoreUI.ScoreUiSetup();
        }
>>>>>>> master
    }
}
