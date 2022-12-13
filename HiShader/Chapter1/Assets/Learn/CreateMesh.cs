using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    // 顶点数组
    Vector3[] vertices = 
    {
        // Front
        new Vector3(-2.0f, 3.0f, -2.0f),
        new Vector3(-2.0f, 0.0f, -2.0f),
        new Vector3(2.0f, 0.0f, -2.0f),
        new Vector3(2.0f, 3.0f, -2.0f),

        // Left  
        new Vector3(-2.0f, 3.0f, -2.0f),
        new Vector3(-2.0f, 0.0f, -2.0f),
        new Vector3(-2.0f, 0.0f, 2.0f),
        new Vector3(-2.0f, 3.0f, 2.0f),
    
        // Back
        new Vector3(-2.0f, 3.0f, 2.0f),
        new Vector3(-2.0f, 0.0f, 2.0f),
        new Vector3(2.0f, 0.0f, 2.0f),
        new Vector3(2.0f, 3.0f, 2.0f),
         
        // Right  
        new Vector3(2.0f, 3.0f, 2.0f),
        new Vector3(2.0f, 0.0f, 2.0f),
        new Vector3(2.0f, 0.0f, -2.0f),
        new Vector3(2.0f, 3.0f, -2.0f),
        
        // Top
        new Vector3(-2.0f, 3.0f, 2.0f),
        new Vector3(2.0f, 3.0f, 2.0f),
        new Vector3(2.0f, 3.0f, -2.0f),
        new Vector3(-2.0f, 3.0f, -2.0f),
        
        // Bottom
        new Vector3(-2.0f, 0.0f, 2.0f),
        new Vector3(2.0f, 0.0f, 2.0f),
        new Vector3(2.0f, 0.0f, -2.0f),
        new Vector3(-2.0f, 0.0f, -2.0f),
    };
    
    // 索引数组
    int[] triangles =
    {
        // Front
        2,1,0,
        0,3,2,
        
        // Left
        4,5,6,
        4,6,7,
        
        // Back
        9,11,8,
        9,10,11,
        
        // Right
        12,13,14,
        12,14,15,
        
        // Top
        16,17,18,
        16,18,19,
        
        // Bottom
        21,23,22,
        21,20,23,
    };
    
    //UV数组
    Vector2[] uvs =
    {
        // Front
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(0.0f, 0.0f),
    
         
        // Left
        new Vector2(1.0f, 1.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(0.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
    
         
        // Back
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(0.0f, 0.0f),
    
         
        // Right
        new Vector2(1.0f, 1.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(0.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
    
        // Top
        new Vector2(0.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
        new Vector2(0.0f, 1.0f),
    
    
        // Bottom
        new Vector2(0.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
        new Vector2(0.0f, 1.0f),
    };
    
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        
        // 法线是根据顶点数据计算出来的,所以在修改完顶点后,我们需要更新一下法线
        mesh.RecalculateNormals();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
