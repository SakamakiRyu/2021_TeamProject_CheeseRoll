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
    [SerializeField] float _timer;
    float _maxTime;
 
    bool _burning = false;

    [SerializeField] GameObject _testObj;

    /// <summary>
    /// アツアツ状態か否か を取得
    /// </summary>
    public bool Burning { get => _burning;}

    private void Update()
    {
        if (_burning)
        {
            _timer += Time.deltaTime;

            if (_timer > _maxTime)
            {
                _burning = false;
                _timer = 0;

                if (_testObj != null)
                {
                    _testObj.SetActive(false);
                }
            }
        }
    }

    //  唐辛子につけてる チーズから呼び出したい？？
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"> HittableObj の Name </param>
    public void StartBurn(string name)
    {
        //Burns nowBurn;
        for (int i = 0; i < _burns.Length; i++)
        {
            if (name == _burns[i].Name)
            {
                //nowBurn = _burns[i];

                if (_maxTime - _timer < _burns[i].Time)
                {
                    _timer = 0;
                    _maxTime = _burns[i].Time;
                    _burning = true;
                }

                //_maxTime = _burns[i].Time;
                //_burning = true;

                if (_testObj != null)
                {
                    _testObj.SetActive(true);
                }
            }
        }



    }
}
