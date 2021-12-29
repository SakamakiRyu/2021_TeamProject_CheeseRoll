using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFade : MonoBehaviour
{
    const float FadeDuration = 25;
    [SerializeField] float _minAspect;
    [SerializeField] float _maxAspect;

    /// <summary>
    /// 円形にフェードインする。
    /// </summary>
    /// <param name="time"></param>
    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeIn()
    {
        while (transform.localScale.x > _minAspect && this.transform.localScale.y > _minAspect)
        {
            float x = transform.localScale.x - FadeDuration * Time.deltaTime;
            float y = transform.localScale.y - FadeDuration * Time.deltaTime;
            Vector3 scale = new Vector3 (x,y,0);
            transform.localScale = scale;
            yield return null;
        }
    }

    IEnumerator DoFadeOut()
    {
        while (transform.localScale.x < _maxAspect && this.transform.localScale.y < _maxAspect)
        {
            float x = transform.localScale.x + FadeDuration * Time.deltaTime;
            float y = transform.localScale.y + FadeDuration * Time.deltaTime;
            Vector3 scale = new Vector3(x, y, 0);
            transform.localScale = scale;
            yield return null;
        }
    }
}
