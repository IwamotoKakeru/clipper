using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon{
    private Vector3[] polyVertices = new Vector3[3];
    public Vector3[] PolyVertices{
        get => polyVertices;
    }

    public Vector3 CrossVector {get; private set;}
    public float Size {get; private set;}
    public Vector3 CenterPos{get; private set;}

    public Polygon(Vector3[] recPolyVertices){
        polyVertices = recPolyVertices;

        CrossVector = Vector3.Cross(
            polyVertices[1] - polyVertices[0],
            polyVertices[2] - polyVertices[0]
        );

        Size = CrossVector.magnitude/2;

        CenterPos = (polyVertices[0]+polyVertices[1]+polyVertices[2])/3;
    }
}

public class WoolGenerator : MonoBehaviour
{
    public GameObject wool = null;
    private Mesh woolMesh = null;

    void Start()
    {
        GenerateOnPlane();
    }

    void GenerateOnPlane(){ 
        woolMesh = GetComponent<MeshFilter>().mesh;

        List<Vector3> vertices = new List<Vector3>();
        List<int> tris = new List<int>();

        vertices.AddRange(woolMesh.vertices);
        tris.AddRange(woolMesh.triangles);

        if(tris.Count%3 != 0) Debug.LogError("Incorrect vertices count!");

        List<Polygon> polygons = new List<Polygon>();

        for(int i=0;i<tris.Count;i=i+3){
            Vector3[] polyVertices={
                vertices[tris[i]], 
                vertices[tris[i+1]], 
                vertices[tris[i+2]]
            };

            polygons.Add(new Polygon(polyVertices));
        }

        foreach(Polygon polygon in polygons){
            Vector3 instantiatePos;
            instantiatePos = transform.TransformPoint(polygon.CenterPos);

            float polySize = polygon.Size;

            Instantiate(wool,instantiatePos,Quaternion.identity,this.transform);
            Debug.Log(polySize);
        }

    }

}
