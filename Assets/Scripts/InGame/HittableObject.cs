using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour
{

    private enum HittableObjectType
    {
        Food = 0,            // 食べ物
        DropOfWater =70,     // 雫
        Recoverey = 80,      // 回復
        RedHeat = 100,          // 唐辛子
        Burn = 110,             // 焦げた
        Fake = 120,             // 偽物

        HittableObject = 150,　// 障害物
    }

    [Space]
    //[Header("ステージ３などの偽物の食べ物の場合は、ObjectTypeを 「シーン上」 で Fake にしてください")]
    [Header("ObjectTypeを 「シーン上」 で Fake にしてください")]
    [Header("ステージ３などの偽物の食べ物の場合は、")]

    [SerializeField] string _name;

    // Fire tag を作って食材を燃やす?

    [SerializeField] string _hitJudgeTag = "Player";
    [SerializeField] HittableObjectType _objectType;

    [SerializeField] UnityEngine.Events.UnityEvent _onItemPickup;

    public string Name { get => _name;}

    GameObject _hitObj;

    //private void Start()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BurningArea")
        {
            if (_objectType == HittableObjectType.Food)
            {
                _objectType = HittableObjectType.Burn;
                //this.gameObject.GetComponentInChildren<Renderer>().material.SetColor("_BaseColor", Color.black);
            }
        }

        if (other.tag == _hitJudgeTag)
        {
            _hitObj = other.gameObject;

            _onItemPickup.Invoke();
            PlayEffect();

            //DebugItem1();

            //DestroyThis();
        }
    }

    private void PlayEffect()
    {
        switch (_objectType)
        {
            case HittableObjectType.Food:
                EffectManager.Instance?.PlayEffect(EffectManager.EffectType.GetItem, this.transform.position);
                AudioManager.Instance.PlaySE(AudioManager.SEtype.IngredientsAcquired);
                break;
            case HittableObjectType.DropOfWater:
                EffectManager.Instance?.PlayEffect(EffectManager.EffectType.Cure, this.transform.position);
                break;
            case HittableObjectType.Recoverey:
                EffectManager.Instance?.PlayEffect(EffectManager.EffectType.Cure, this.transform.position);
                AudioManager.Instance.PlaySE(AudioManager.SEtype.RecoveryItem);
                break;
            case HittableObjectType.RedHeat:
                AudioManager.Instance.PlaySE(AudioManager.SEtype.BlowTheFire);
                break;
            case HittableObjectType.Burn:
                break;
            case HittableObjectType.HittableObject:
                break;
            case HittableObjectType.Fake:
                AudioManager.Instance.PlaySE(AudioManager.SEtype.BurntIngredientsAcquired);
                break;
            default:
                break;
        }
    }

    public void AddScore()
    {
        if ((int)_objectType == 0)
        {
            ScoreManager.Instance.ScoreStructure.ScoreUp(_name);
        }
        else if ((int)_objectType == 110)
        {
            ScoreManager.Instance.ScoreStructure.BurntFoodCountUp();
        }
        else if ((int)_objectType == 120)
        {
            ScoreManager.Instance.ScoreStructure.FaketFoodCountUp();
        }
    }

    public void StartBurning()
    {
        _hitObj.GetComponent<BurningCheese>().StartBurn(_name, true);
    }

    /// <summary>
    /// DropOfWater ならアツアツ状態じゃなくす
    /// </summary>
    public void EndBurning()
    {
        if (_objectType == HittableObjectType.DropOfWater)
        {
            _hitObj.GetComponent<BurningCheese>().EndBurn("Water");
        }
    }

    /// <summary>
    /// Debug.Log を出す。GameObjectの名前、Nameに入ってる単語、オブジェクトタイプが出る
    /// </summary>
    public void DebugItem1()
    {
        Debug.Log($"Hit {this.name} {Name} {_objectType}");

        //if ((int)_objectType >= 150)
        //{
        //    Debug.Log($"Hit {this.name} {Name} {_objectType}");
        //}
        //else if ((int)_objectType >= 100)
        //{
        //    Debug.Log($"Burning {this.name} {Name} {_objectType}");
        //}
        //else if ((int)_objectType >= 80)
        //{
        //    Debug.Log($"Recoverey {this.name} {Name} {_objectType}");
        //}
        //else
        //{
        //    Debug.Log($"Food {this.name} {Name} {_objectType}");
        //}
    }

    /// <summary>
    /// 0.1f 後にGameObjectを破壊
    /// </summary>
    public void DestroyThis()
    {
        Destroy(this.gameObject, 0.1f);
    }

    /// <summary>
    /// 非アクティブにする
    /// </summary>
    public void ActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
