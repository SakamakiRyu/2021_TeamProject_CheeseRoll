using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class RoadChip : MonoBehaviour
{
    [SerializeField]
    MeshFilter _meshFilter;
    [SerializeField]
    MeshCollider _meshCollider;

    Vector3 _wallVector;

    /// <summary>
    /// 壁擦りベクトル
    /// </summary>
    public Vector3 WallVector => _wallVector;

    public void Init(float width, float height)
    {
        //メッシュ生成
        Mesh mesh = new Mesh();

        //頂点の配列
        Vector3[] vertices = new Vector3[8];
        //手前の左下、右下、左上、右上
        vertices[0] = new Vector3(-width, -height, 0);
        vertices[1] = new Vector3(width, -height, 0);
        vertices[2] = new Vector3(-width, height, 0);
        vertices[3] = new Vector3(width, height, 0);
        //奥のの左下、右下、左上、右上
        vertices[4] = new Vector3(-width, -height, 0);
        vertices[5] = new Vector3(width, -height, 0);
        vertices[6] = new Vector3(-width, height, 0);
        vertices[7] = new Vector3(width, height, 0);

        //壁擦りベクトルの作成
        MakeWallVector(vertices[3], vertices[7]);

        mesh.vertices = vertices;

        //uv設定(あとでかく)

        //三角形
        mesh.triangles = new int[] {1, 3, 7, 7, 5, 1,
                                    3, 2, 6, 6, 7, 3,
                                    0, 1, 4, 4, 1, 5};

        //領域と法線の計算
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        _meshFilter.mesh = mesh;
        //下のは極端に小さいとエラーになるらしい
        //_meshCollider.sharedMesh = mesh;

    }

    public Vector3[] GetVertices()
    {
        return _meshFilter.mesh.vertices;
    }

    public void SetVertices(Vector3[] vertices)
    {
        Mesh mesh = _meshFilter.mesh;
        mesh.vertices = vertices;
        //壁擦りベクトルの作成
        MakeWallVector(vertices[3], vertices[7]);

        //領域と法線の計算
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        _meshFilter.mesh = mesh;
        _meshCollider.sharedMesh = mesh;
    }

    private void MakeWallVector(Vector3 from, Vector3 to)
    {
        _wallVector = to - from;
    }
}
