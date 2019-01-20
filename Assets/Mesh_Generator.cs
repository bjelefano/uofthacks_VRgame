using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mesh_Generator : MonoBehaviour
{
    public Material mat;
    float width = 0.5f;
    float depth = 0.5f;
    float length = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[6];

        /*vertices[0] = new Vector3(-width, -depth);
        vertices[1] = new Vector3(-width, depth);
        vertices[2] = new Vector3(width, depth);
        vertices[3] = new Vector3(width, -depth);*/

        //gem
        vertices[0] = new Vector3(-width, 0, -depth);
        vertices[1] = new Vector3(width, 0, -depth);
        vertices[2] = new Vector3(width, 0, depth);
        vertices[3] = new Vector3(-width, 0, depth);
        vertices[4] = new Vector3(0, length, 0);
        vertices[5] = new Vector3(0, -length, 0);

        mesh.vertices = vertices;

        mesh.triangles = new int[] { 0, 1, 4, 1, 2, 4, 2, 3, 4, 3, 0, 4, 0, 1, 5, 1, 2, 5, 2, 3, 5, 3, 0, 5};

        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshRenderer>().material = mat;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
