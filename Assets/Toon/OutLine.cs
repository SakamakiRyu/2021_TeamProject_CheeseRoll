using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour
{
    public Material OutlineMaterial;
    private float _outlineScaleFactor;
    private Color _outlineColor;
    private Renderer _outlineRenderer;

    void Start()
    {
        if (SceneManager.Instance?.CurrentScene != "Result")
        {
            _outlineRenderer = CreateOutline(OutlineMaterial, _outlineScaleFactor, _outlineColor);
            _outlineRenderer.enabled = true;
        }
    }

    void Update()
    {

    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend = outlineObject.GetComponent<Renderer>();
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_ScaleFactor", scaleFactor);
        rend.material = outlineMat;
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineObject.GetComponent<OutLine>().enabled = false;
        rend.enabled = false;
        return rend;
    }
}
