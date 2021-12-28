using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class BurningCheese : MonoBehaviour
{

    [System.Serializable]
    class Burn
    {
        [SerializeField/*,Header("")*/] string _name;
        [SerializeField, Tooltip("鉄板の時は使いません")] float _time;

        [SerializeField, Tooltip("優先度 BurningMultiplicationの優先度")] int _priority;
        [SerializeField, Range(1f, 10)] float _burningMultiplication;

        bool isUseTimer = false;

        public Burn(Burn burns, bool useTimer)
        {
            _name = burns.Name;
            _time = burns.Time;
            _priority = burns.Priority;
            _burningMultiplication = burns.BurningMultiplication;
            isUseTimer = useTimer;
        }
        private Burn()
        {
            _burningMultiplication = 1.0f; // これができるなら、構造でも初期値ができる？ 
        }

        public string Name { get => _name; }
        public float Time { get => _time; }
        public int Priority { get => _priority; }
        public float BurningMultiplication { get => _burningMultiplication; }

        public bool IsUseTimer
        {
            get => isUseTimer;
            //set => isUseTimer = value;
        }

        public float DecreasedTime(float timer)
        {
            _time -= timer;
            return _time;
        }
    }

    //[Header("名前はきちんと合わせてください")]
    [SerializeField] Burn[] _burns;

    float _timer;
    float _maxTime;

    Burn _nowBurn = null; // デバッグだとNullにならない

    List<Burn> _validBurns = new List<Burn>();


    [SerializeField, UnityEngine.Serialization.FormerlySerializedAs("_testObj")] GameObject _judgArea;
    [SerializeField] GameObject _fireUi;
    [SerializeField] RoadColorChange _roadColorChange;

    private void Awake()
    {
        if (_nowBurn?.Name == "") { _nowBurn = null; }
        _validBurns = new List<Burn>();
    }

    /// <summary>
    /// アツアツ状態か否か を取得
    /// </summary>
    public bool IsBurning
    {
        get => _nowBurn != null;
    }

    public float BurningMultiplication 
    {
        get 
        {
            return _nowBurn?.BurningMultiplication ?? 1.0f;

            //if (_nowBurn == null) { return 1.0f; }
            //return _nowBurn.BurningMultiplication; 
        }
    }


    private void Update()
    {
        if (_nowBurn != null)
        {
            _timer += Time.deltaTime;

            if (_timer > _maxTime)
            {
                EndBurn(ref _nowBurn);
            }
        }
    }

    public void StartBurn(string burnName,bool doTimer)
    {
        foreach (var item in _burns)
        {
            if (burnName == item.Name)
            {
                var newBurn = new Burn(item, doTimer);
                _validBurns.Add(newBurn);

                _validBurns = _validBurns.OrderByDescending(x => x.Priority).ToList();


                if (newBurn.Priority >= (_nowBurn?.Priority ?? newBurn.Priority))
                {
                    if ((_nowBurn?.IsUseTimer ?? false) == true)
                    {
                        RefreshTimerAndBurns();
                    }

                    _nowBurn = newBurn;
                }

                if (doTimer)
                {
                    _timer = 0;
                    _maxTime = newBurn.Time;
                }

                //Debug.Log(burnName);

                DirectingBurn(true);

                return;
            }
        }
    }

    public void EndBurn(string burnName) // NonTimer Water
    {
        if (_validBurns.Where(x => x.Name == burnName).FirstOrDefault() != null)
        {
            Burn _ = _validBurns.First(item => item.Name == burnName);

            _validBurns.Remove(_);
            if (_nowBurn == _)
            {
                _nowBurn = _validBurns?.FirstOrDefault() ?? null;
            }

        }
        else if (burnName == "Water") //sizuku
        {
            _validBurns.RemoveAll(x => x.IsUseTimer == true);
            _timer = 0;

            if (_nowBurn?.IsUseTimer ?? false == true)
            {
                //_nowBurn = null; 
                _nowBurn = _validBurns?.FirstOrDefault() ?? null;
            }

        }

        DirectingBurn(false);
    }

    private void EndBurn(ref Burn now) // Timer
    {
        if (now.IsUseTimer == false)
        {
            RefreshTimerAndBurns();

        }
        else
        {
            _validBurns.Remove(now);
            now = null;

            RefreshTimerAndBurns();

            if (_validBurns.Any() == true)
            {
                now = _validBurns.First();
            }

            _nowBurn = now; // いらない？

        }

        DirectingBurn(false);
    }

    private void RefreshTimerAndBurns()
    {
        _validBurns.Where(x => x.IsUseTimer == true).ToList().RemoveAll(x => x.DecreasedTime(_timer) <= 0);
        _timer = 0;

        _maxTime = _validBurns?.Where(x => x.IsUseTimer == true)?.FirstOrDefault()?.Time ?? 10;
    }

    private void DirectingBurn(bool isStrat)
    {
        //if (_nowBurn != null)
        if ((_validBurns?.Any() ?? false) == true)
        {
            var x = _validBurns?.Any(x => x.IsUseTimer == true) ?? false;
            //Debug.Log($"x:{x} is:{isStrat} {isStrat && x}");

            if (_judgArea != null)
            {
                _judgArea.SetActive(isStrat && x);
            }

            if (_fireUi != null)
            {
                _fireUi.SetActive(isStrat && x);
            }

            if (_roadColorChange != null)
            {
                _roadColorChange.HeatingRoadMaterial();
            }
        }
        else
        {
            if (_judgArea != null)
            {
                _judgArea.SetActive(false);
            }

            if (_fireUi != null)
            {
                _fireUi.SetActive(false);
            }

            if (_roadColorChange != null)
            {
                _roadColorChange.ResetRoadMaterial();
            }

        }


    }

}
