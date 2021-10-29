using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour
{
    private enum HittableObjectType
    {
        Food = 0,            // 食べ物
        Enemy = 100,           // 敵
        HittableObject = 150,　// 障害物
    }

    [SerializeField] string _hitJudgeTag = "Player";
    [SerializeField] HittableObjectType _objectType;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _hitJudgeTag)
        {
            if(100 <= (int)_objectType)
            {
                Debug.Log("Hit " + this.name);
            }
            else
            {
                Debug.Log("Food " + this.name);
            }


            Destroy(this.gameObject, 0.1f);
        }
    }
}
