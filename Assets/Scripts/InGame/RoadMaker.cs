using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    //生成したオブジェクトの収納先
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private float _splitTime;
    [SerializeField]
    private RoadChip _roadPrefab;
    [SerializeField]
    private float _roadSizeX;
    [SerializeField]
    private float _roadSizeY;

    private float _timer;
    private RoadChip _cullentChip;


    private bool _nowPlay = true;

    /// <summary> 道を生成 するか否か </summary>
    public bool NowPlay { set => _nowPlay = value; }

    private void Start()
    {
        MakeNewChip();
    }

    private void Update()
    {
        if (_nowPlay)
        {
            StretchRoad();
            _timer += Time.deltaTime;
            if (_timer > _splitTime)
            {
                _timer -= _splitTime;
                Split();
            }
        }
    }

    private void Split()
    {
        MakeNewChip();
    }

    private void StretchRoad()
    {
        Vector3[] vertices = _cullentChip.GetVertices();
        Vector3 diffPos = this.transform.position - _cullentChip.transform.position;
        float length = diffPos.z;
        float height = diffPos.y;

        vertices[4] = new Vector3(-_roadSizeX, -_roadSizeY + height, length);
        vertices[5] = new Vector3(_roadSizeX, -_roadSizeY + height, length);
        vertices[6] = new Vector3(-_roadSizeX, _roadSizeY + height, length);
        vertices[7] = new Vector3(_roadSizeX, _roadSizeY + height, length);

        _cullentChip.SetVertices(vertices);
    }

    private void MakeNewChip()
    {
        RoadChip newChip = Instantiate(_roadPrefab, _container);
        newChip.transform.position = this.transform.position;
        newChip.Init(_roadSizeX, _roadSizeY);
        _cullentChip = newChip;
    }
}
