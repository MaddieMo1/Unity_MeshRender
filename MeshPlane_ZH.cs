using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPlane_ZH : MonoBehaviour
{
    MeshFilter _MeshFilter;
    MeshRenderer _MeshRender;
    MeshCollider _MeshCollider;

    //顶点数据 数组
    List<Vector3> _Verts;
    List<int> _Indices;

    [Header("网格渲染行")]
    public int _Row = 10;
    [Header("网格渲染列")]
    public int _Line = 10;

    [Header("网格间距")]
    public float _Width = 0.1f;
    [Header("网格高度")]
    public float _Height = 0.0f;

    void Start()
    {

        _Verts = new List<Vector3>();
        _Indices = new List<int>();

        _MeshFilter = GetComponent<MeshFilter>();
        _MeshRender = GetComponent<MeshRenderer>();
        _MeshCollider = GetComponent<MeshCollider>();

        Generate();
    }

    //数据生成
    public void Generate()
    {
        //数据清除
        CleraMeshData();
        //数据填充
        AddMeshData();


        //数据传递给 Mesh 生成网格数据
        //构造Mesh对象  
        Mesh _Mesh = new Mesh();
        //顶点数据加载读取
        _Mesh.vertices = _Verts.ToArray();
        //渲染序列加载读取
        _Mesh.triangles = _Indices.ToArray();

        //UV数据加载读取
        //_Mesh.uv = _Uvs.ToArray();

        //从顶点重新计算网格的边界体积。
        _Mesh.RecalculateNormals();
        //从三角形和顶点重新计算网格的法线
        _Mesh.RecalculateBounds();

        //网格数据加载
        _MeshFilter.mesh = _Mesh;
        //碰撞体添加
        _MeshCollider.sharedMesh = _Mesh;
    }
    //数据清除
    private void CleraMeshData()
    {
        _Verts.Clear();
        _Indices.Clear();
    }
    //数据填充
    private void AddMeshData()
    {

        //顶点赋值
        for (int z = 0; z < _Line; z++)
        {
            for (int x = 0; x < _Row; x++)
            {
                //每个顶点的坐标
                Vector3 p = new Vector3(x, _Height, z) * _Width;
                _Verts.Add(p);
            }
        }

        //三角面渲染  排除最后一行和最后一列
        for (int z = 0; z < _Line - 1; z++)
        {
            for (int x = 0; x < _Row - 1; x++)
            {
                //三角面渲染
                int _Index0 = z * _Row + x;                  //左下角     0
                int _Index1 = z * _Row + x + 1;              //右下角     1
                int _Index2 = (z + 1) * _Row + x + 1;        //右上角     2
                int _Index3 = (z + 1) * _Row + x;            //左上角     3

                //存储渲染序列
                _Indices.Add(_Index0); _Indices.Add(_Index3); _Indices.Add(_Index2); //渲染第一个三角面  0 3 2
                _Indices.Add(_Index0); _Indices.Add(_Index2); _Indices.Add(_Index1); //渲染第二个三角面  0 2 1
            }
        }
    }
}
