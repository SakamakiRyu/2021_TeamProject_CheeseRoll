using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    
    [SerializeField]
    private float _splitLength;
    private float _latesetSplitPosz;
    [SerializeField]
    private RoadChip _roadPrefab;
    [SerializeField]
    private float _roadSizeX;
    [SerializeField]
    private float _roadSizeY;

    private RoadChip _cullentChip;
    //生成したオブジェクトの収納先
    private Transform _container;


    private bool _nowPlay = true;

    /// <summary> 道を生成 するか否か </summary>
    public bool NowPlay { set => _nowPlay = value; get => _nowPlay; }

    private void Awake()
    {
        _container = new GameObject("Roads").transform;
    }

    private void Start()
    {
        MakeNewChip();
    }

    private void Update()
    {
        if (_nowPlay)
        {
            StretchRoad();
            if (this.transform.position.z - _latesetSplitPosz > _splitLength)
            {
                Split();
                _latesetSplitPosz = this.transform.position.z;
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
