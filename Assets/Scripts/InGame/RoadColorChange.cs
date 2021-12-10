using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadColorChange : MonoBehaviour
{
    [SerializeField] GameObject _roadPrefab;

    [SerializeField] Material _resetRoadMaterial;
    [SerializeField] Material _heatingRoadMaterial;

    private void Awake()
    {

        ResetRoadMaterial();
    }

    public void ResetRoadMaterial()
    {
        ChangeMaterial(_resetRoadMaterial);
    }

    public void HeatingRoadMaterial()
    {
        ChangeMaterial(_heatingRoadMaterial);
    }

    private void ChangeMaterial(Material next)
    {
        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("Color_7c2c9ab94c004508a97a96a7d632d94a", next.GetColor("Color_7c2c9ab94c004508a97a96a7d632d94a"));
        _roadPrefab.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f", next.GetFloat("Vector1_7f81bc3aefce435690e6f3a0dfadfa2f"));
    }
}
