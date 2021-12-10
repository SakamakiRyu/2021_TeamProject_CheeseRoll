using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadColorChange : MonoBehaviour
{
    [SerializeField] GameObject _roadPrefab;

    [SerializeField] Material _resetRoadMaterial;
    [SerializeField] Material _heatingRoadMaterial;

    Material _nowMatelial;
    Material _nextMaterial;
    bool _nowChange = false;
    float _time = 0;

    private void Awake()
    {
        //ResetRoadMaterial();
        ChangeMaterial(_resetRoadMaterial);
    }

    private void Update()
    {
        if(_nowChange == true)
        {
            _time += Time.deltaTime * 0.1f;
            LerpChangeMaterial(_time);
        }
    }

    public void ResetRoadMaterial()
    {
        //ChangeMaterial(_resetRoadMaterial);
        StartChangeMaterial(_resetRoadMaterial);
    }

    public void HeatingRoadMaterial()
    {
        //ChangeMaterial(_heatingRoadMaterial);
        StartChangeMaterial(_heatingRoadMaterial);
    }


    private void ChangeMaterial(Material next)
    {
        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("Color_7c2c9ab94c004508a97a96a7d632d94a", next.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a"));
        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f", next.GetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f"));
    }


    private void LerpChangeMaterial(float t)
    {
        /*
        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("Color_7c2c9ab94c004508a97a96a7d632d94a",
            Color.Lerp(_roadPrefab.GetComponent<Renderer>().sharedMaterial.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a"), _nextMaterial.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a"), t));

        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f",
            Mathf.Lerp(_roadPrefab.GetComponent<Renderer>().sharedMaterial.GetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f"), _nextMaterial.GetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f"), t));
        */


        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("Color_7c2c9ab94c004508a97a96a7d632d94a",
            Color.Lerp(_nowMatelial.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a"), _nextMaterial.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a"), t));

        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f",
            Mathf.Lerp(_nowMatelial.GetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f"), _nextMaterial.GetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f"), t));
    }

    private void StartChangeMaterial(Material next)
    {
        _nowMatelial = _roadPrefab.GetComponent<Renderer>().sharedMaterial;
        _nextMaterial = next;
        _time = 0;
        _nowChange = true;
    }

    //[System.Serializable]
    //struct MaterialChanges
    //{
    //    [SerializeField] string name;
    //    [SerializeField] string vari;
    //}
}
