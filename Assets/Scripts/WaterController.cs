using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
     public float shakeSpeed;

     public MeshFilter meshF;

     private Mesh mesh;

     private List<int> trianglesIndices;

     private List<Vector3> vertices;

     private int length;


    void Start()
    {
    	mesh=meshF.mesh;

        vertices=new List<Vector3>();

        trianglesIndices=new List<int>();

        for(int i=0;i<mesh.vertices.Length;i++)
            {
    	        vertices.Add(mesh.vertices[i]);
        
            }

        mesh.GetTriangles(trianglesIndices,0);
        
        length=vertices.Count;
    }


    void Update()
    {
    	Destroy(this.gameObject.GetComponent<MeshCollider>());
    	
        int j=0;

        for(int i=0;i<mesh.vertices.Length;i++)
        {
        	j+=3;
        	vertices[i]=new Vector3(vertices[i].x ,Mathf.PerlinNoise(j*.01f*Time.time, i*.1f*shakeSpeed*Time.time) ,vertices[i].z );
        }
        
        mesh.SetVertices(vertices);
        
        this.gameObject.AddComponent<MeshCollider>();
    }
}
