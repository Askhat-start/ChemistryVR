using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class SmoothPyramidGenerator : MonoBehaviour
{
    public float height = 2f;
    public float baseWidth = 2f;

    void Start()
    {
        GenerateSmoothPyramid();
    }

    void GenerateSmoothPyramid()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        mesh.Clear();

        Vector3[] vertices = new Vector3[5];

        // Vertices for the base of the pyramid
        vertices[0] = new Vector3(-baseWidth / 2, 0f, -baseWidth / 2);
        vertices[1] = new Vector3(baseWidth / 2, 0f, -baseWidth / 2);
        vertices[2] = new Vector3(baseWidth / 2, 0f, baseWidth / 2);
        vertices[3] = new Vector3(-baseWidth / 2, 0f, baseWidth / 2);

        // Vertex for the top of the pyramid
        vertices[4] = new Vector3(0f, height, 0f);

        mesh.vertices = vertices;

        int[] triangles = new int[]
        {
            // Base triangles
            0, 1, 2,
            0, 2, 3,
            
            // Side triangles
            0, 4, 1,
            1, 4, 2,
            2, 4, 3,
            3, 4, 0
        };

        mesh.triangles = triangles;

        // Calculate normals for smooth shading
        Vector3[] normals = new Vector3[5];
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = Vector3.up;
        }
        mesh.normals = normals;

        // Automatically recalculate bounds for correct rendering
        mesh.RecalculateBounds();
    }
}
