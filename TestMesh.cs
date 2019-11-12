using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMesh : MonoBehaviour
{
    MeshFilter _MeshFilter;
    MeshRenderer _MeshRender;
    MeshCollider _MeshCollider;
    void Start()
    {
        _MeshFilter = GetComponent<MeshFilter>();
        _MeshRender = GetComponent<MeshRenderer>();
        _MeshCollider = GetComponent<MeshCollider>();

        BuildPlane();
    }

    //网格渲染
    private void BuildPlane()
    {
        //顶点数据
        List<Vector3> _Verts = new List<Vector3>();
        //序号列表
        List<int> _Indices = new List<int>();

        //顶点信息
        _Verts.Add(new Vector3(0, 0, 0));
        _Verts.Add(new Vector3(1, 0, 0));
        _Verts.Add(new Vector3(1, 0, 1));
        _Verts.Add(new Vector3(0, 0, 1));

        _Verts.Add(new Vector3(0, 1, 0));
        _Verts.Add(new Vector3(1, 1, 0));
        _Verts.Add(new Vector3(1, 1, 1));
        _Verts.Add(new Vector3(0, 1, 1));


        //底
        _Indices.Add(0);
        _Indices.Add(1);
        _Indices.Add(2);
        _Indices.Add(0);
        _Indices.Add(2);
        _Indices.Add(3);
        //顶
        _Indices.Add(4);
        _Indices.Add(7);
        _Indices.Add(6);
        _Indices.Add(4);
        _Indices.Add(6);
        _Indices.Add(5);
        //前
        _Indices.Add(2);
        _Indices.Add(6);
        _Indices.Add(3);
        _Indices.Add(3);
        _Indices.Add(6);
        _Indices.Add(7);
        //后 
        _Indices.Add(0);
        _Indices.Add(5);
        _Indices.Add(1);
        _Indices.Add(0);
        _Indices.Add(4);
        _Indices.Add(5);
        //左
        _Indices.Add(0);
        _Indices.Add(7);
        _Indices.Add(4);
        _Indices.Add(0);
        _Indices.Add(3);
        _Indices.Add(7);
        //右
        _Indices.Add(1);
        _Indices.Add(5);
        _Indices.Add(2);
        _Indices.Add(5);
        _Indices.Add(6);
        _Indices.Add(2);


        //Mesh构建以及渲染

        //构造Mesh对象   
        Mesh _Mesh = new Mesh();
        _Mesh.vertices = _Verts.ToArray();
        _Mesh.triangles = _Indices.ToArray();

        //从顶点重新计算网格的边界体积。
        _Mesh.RecalculateBounds();
        //从三角形和顶点重新计算网格的法线
        _Mesh.RecalculateNormals();

        _MeshFilter.mesh = _Mesh;
        

    }
}
