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

    [SerializeField] GameObject _fireUi;

    //[SerializeField] Material _road;
    //Ray _ray;
    //RaycastHit _hit;
    //Vector3 _direction = new Vector3(0, -1, 0);

    /// <summary>
    /// アツアツ状態か否か を取得
    /// </summary>
    public bool Burning { get => _burning;}

    private void Update()
    {
        if (_burning)
        {
            //_ray = new Ray(_testObj.transform.position, _direction);
            //if(Physics.Raycast(_ray,out _hit, 3))
            //{
            //    if(_hit.transform.name== "RoadChip(Clone)")
            //    {
            //        _hit.transform.GetComponent<Renderer>().material = _road;

            //        //Material material = _hit.transform.GetComponent<Renderer>().material;

            //        //Color color = material.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a");
            //        ////color
            //        //material.SetColor("Color_7c2c9ab94c004508a97a96a7d632d94a", color);
            //        //_hit.transform.GetComponent<Renderer>().material = material;
            //    }
            //}

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
        _burning = false;
        _timer = 0;

        if (_testObj != null)
        {
            _testObj.SetActive(false);
        }

        if (_fireUi != null)
        {
            _fireUi.SetActive(false);
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
                    _burning = true;
                }

                if (_testObj != null)
                {
                    _testObj.SetActive(true);
                }

                if (_fireUi != null)
                {
                    _fireUi.SetActive(true);
                }
            }
        }



    }
}
