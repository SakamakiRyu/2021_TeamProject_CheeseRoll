using System.Collections;
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

    [SerializeField] string _hitJudgeTag = "Player";
    [SerializeField] HittableObjectType _objectType;

    //private void Start()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _hitJudgeTag)
        {
            if((int)_objectType >= 150)
            {
                Debug.Log($"Hit {this.name} {_objectType}");
            }
            else if((int)_objectType >= 100)
            {
                Debug.Log($"Hit {this.name} {_objectType}");
            }
            else if((int)_objectType >= 80)
            {
                Debug.Log($"Ge {this.name} {_objectType}");
            }
            else
            {
                Debug.Log($"Food {this.name} {_objectType}");
            }


            Destroy(this.gameObject, 0.1f);
        }
    }
}
