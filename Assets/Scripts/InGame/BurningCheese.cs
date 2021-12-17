using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningCheese : MonoBehaviour
{
    [System.Serializable]
    struct Burns
    {
        [SerializeField] string name;
        [SerializeField] float time;

        public string Name { get => name;}
        public float Time { get => time;}
    }

    [SerializeField] Burns[] _burns;
    float _timer;
    float _maxTime;

    [SerializeField,Range(1,10)] float _hpDamegeMagni = 2.0f;

    bool _isBurning = false;

    [SerializeField,UnityEngine.Serialization.FormerlySerializedAs("_testObj")] GameObject _judgArea;

    [SerializeField] GameObject _fireUi;

    [SerializeField] RoadColorChange _roadColorChange;

    /// <summary>
    /// アツアツ状態か否か を取得
    /// </summary>
    public bool IsBurning { get => _isBurning;}
    public float HpDamegeMagni { get => _hpDamegeMagni;}

    private void Update()
    {
        if (_isBurning == true)
        {

            _timer += Time.deltaTime;

            if (_timer > _maxTime)
            {
                EndBurn();
            }
        }
    }

    /// <summary>
    /// アツアツ状態を終了する
    /// </summary>
    public void EndBurn()
    {
        _isBurning = false;
        _timer = 0;

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

    /// <summary>
    /// アツアツ状態を始める
    /// </summary>
    /// <param name="name"> HittableObj の Name </param>
    public void StartBurn(string name)
    {
        for (int i = 0; i < _burns.Length; i++)
        {
            if (name == _burns[i].Name)
            {
                if (_maxTime - _timer < _burns[i].Time)
                {
                    _timer = 0;
                    _maxTime = _burns[i].Time;
                    _isBurning = true;
                }

                if (_judgArea != null)
                {
                    _judgArea.SetActive(true);
                }

                if (_fireUi != null)
                {
                    _fireUi.SetActive(true);
                }

                if (_roadColorChange != null)
                {
                    _roadColorChange.HeatingRoadMaterial();
                }


            }
        }
    }


}
