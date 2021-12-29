using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFade : MonoBehaviour
{
    const float FadeDuration = 50;
    [SerializeField] float _minAspect;
    [SerializeField] float _maxAspect;

    /// <summary>
    /// �~�`�Ƀt�F�[�h�C������B
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
        //�����T�C�Y�܂Ŋg��
        {
            float x = _maxAspect;
            float y = _maxAspect;
            Vector3 scale = new Vector3(x, y, 0);
            transform.localScale = scale;
            yield return null;
        }
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
        //�����T�C�Y�܂ŏk��
        {
            float x = _minAspect;
            float y = _minAspect;
            Vector3 scale = new Vector3(x, y, 0);
            transform.localScale = scale;
            yield return null;
        }
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
