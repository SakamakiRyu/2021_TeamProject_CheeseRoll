using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarFiller : MonoBehaviour
{
    [SerializeField] StarFiller _star;
    Image _image;
    

    public void StarFill(float score)
    {
        
        _image = GetComponent<Image>();
        if (score - 1 > 0)
        {
            //‘S•”õ‚ß‚é
            //ŽŸ‚Ì“z‚ðõ‚ß‚é
            score -= 1;
            StartCoroutine(Fill(1, score));
        }
        if (score - 1 == -0.5f)
        {
            //”¼•ªõ‚ß‚é
            StartCoroutine(Fill(0.5f, 0));
        }
        if (score - 1 == 0)
        {
            //‘S•”õ‚ß‚é
            StartCoroutine(Fill(1, 0));
        }
    }

    public IEnumerator Fill(float fillArea, float remaingScore)
    {
        while (_image.fillAmount != fillArea)
        {
            _image.fillAmount += 0.01f;
            if (_image.fillAmount > fillArea)
            {
                break;
            }
            yield return new WaitForSeconds(0.005f);
        }
        if (remaingScore != 0)
        {
            _star.StarFill(remaingScore);
        }
    }
}
