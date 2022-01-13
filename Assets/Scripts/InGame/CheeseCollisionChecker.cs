using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// チーズの着地判定を取る
/// </summary>
public class CheeseCollisionChecker : MonoBehaviour
{
    const float WaitTime = 0.5f;
    bool _isCollision;
    bool _isCollisionPre;
    float _timer;
    public bool IsGroundEnter { get; private set; }
    public bool IsAir { get; private set; }

    public Quaternion TrailLookAt { get; set; }
    public void GroundEnterUsed() => IsGroundEnter = false;

    [SerializeField]
    ParticleSystem runEffectBase;
    [SerializeField]
    ParticleSystem runEffectTrail;

    private void FixedUpdate()
    {
        _timer -= Time.deltaTime;
        _timer = Mathf.Max(-1.0f, _timer);
        if (_isCollision && !_isCollisionPre)
        {
            if (_isCollision && _timer < 0)
            {
                IsGroundEnter = true;
            }
            _timer = WaitTime;
        }
        if (_isCollision)
        {
            IsAir = false;
        }
        else
        {
            IsAir = true;
        }
        _isCollisionPre = _isCollision;
        _isCollision = false;

        EffectUpdate();
    }

    float timer;
    private void EffectUpdate()
    {
        var main = runEffectTrail.main;
        main.startRotationX = Mathf.Deg2Rad * TrailLookAt.eulerAngles.x;
        main.startRotationY = TrailLookAt.eulerAngles.y;
        main.startRotationZ = TrailLookAt.eulerAngles.z;

        runEffectTrail.transform.localScale = this.transform.localScale;
        runEffectBase.transform.localScale = this.transform.localScale;

        if (_isCollisionPre && (!Cheese.Instance?.IsHide ?? false))
        {
            var e = runEffectTrail.emission;
            e.enabled = true;
            runEffectBase.gameObject.SetActive(true);
            timer = 0.25f;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                var e = runEffectTrail.emission;
                e.enabled = false;
                runEffectBase.gameObject.SetActive(false);
                timer = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isCollision = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        _isCollision = true;
    }
}
