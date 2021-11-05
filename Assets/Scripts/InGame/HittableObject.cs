﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour
{
    private enum HittableObjectType
    {
        Food = 0,            // 食べ物
        Recoverey = 80,      // 回復
        RedHeat = 100,          // 唐辛子
        Burn = 110,             // 焦げた
        HittableObject = 150,　// 障害物
    }

    [SerializeField] string _name;

    // Fire tag を作って食材を燃やす?

    [SerializeField] string _hitJudgeTag = "Player";
    [SerializeField] HittableObjectType _objectType;

    [SerializeField] UnityEngine.Events.UnityEvent _onItemPickup;

    public string Name { get => _name;}

    //private void Start()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _hitJudgeTag)
        {
            _onItemPickup.Invoke();

            //DebugItem1();

            //DestroyThis();
        }
    }

    /// <summary>
    /// Debug.Log を出す。GameObjectの名前、Nameに入ってる単語、オブジェクトタイプが出る
    /// </summary>
    public void DebugItem1()
    {
        if ((int)_objectType >= 150)
        {
            Debug.Log($"Hit {this.name} {Name} {_objectType}");
        }
        else if ((int)_objectType >= 100)
        {
            Debug.Log($"Burning {this.name} {Name} {_objectType}");
        }
        else if ((int)_objectType >= 80)
        {
            Debug.Log($"Recoverey {this.name} {Name} {_objectType}");
        }
        else
        {
            Debug.Log($"Food {this.name} {Name} {_objectType}");
        }
    }

    /// <summary>
    /// 0.1f 後にGameObjectを破壊
    /// </summary>
    public void DestroyThis()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
