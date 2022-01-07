using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarFiller : MonoBehaviour
{
    [SerializeField] StarFiller _star;
    Image _image;
    

    public void StarFill(float score, float fillSpeed = 5.0f)
    {
        
        _image = GetComponent<Image>();
        if (score - 1 > 0)
        {
            //‘S•”õ‚ß‚é
            //ŽŸ‚Ì“z‚ðõ‚ß‚é
            score -= 1;
            StartCoroutine(Fill(1, score, fillSpeed));
        }
        if (score - 1 == -0.5f)
        {
            //”¼•ªõ‚ß‚é
            StartCoroutine(Fill(0.5f, 0, fillSpeed));
        }
        if (score - 1 == 0)
        {
            //‘S•”õ‚ß‚é
            StartCoroutine(Fill(1, 0, fillSpeed));
        }
    }

    public IEnumerator Fill(float fillArea, float remaingScore, float fillSpeed)
    {
        while (_image.fillAmount != fillArea)
        {
            _image.fillAmount += Time.deltaTime * fillSpeed;
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
