using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon{
    private Vector3[] polyVertices = new Vector3[3];
    public Vector3[] PolyVertices{
        get => polyVertices;
    }

    public Polygon(Vector3[] recPolyVertices){
        polyVertices = recPolyVertices;
    }

    public Vector3 GetCrossVector(){
        Vector3 crossVector;
        
        crossVector = Vector3.Cross(
            polyVertices[1] - polyVertices[0],
            polyVertices[2] - polyVertices[0]
        );

        return crossVector;
    }

    public float GetPolySize(){
        return GetCrossVector().magnitude/2;
    }

    public Vector3 GetPolyCenterPos(){
        Vector3 CenterPos;

        CenterPos = (polyVertices[0]+polyVertices[1]+polyVertices[2])/3;

        return CenterPos;
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
            instantiatePos = transform.TransformPoint(polygon.GetPolyCenterPos());
            Instantiate(wool,instantiatePos,Quaternion.identity,this.transform);
        }

        Debug.Log(vertices.Count);
        Debug.Log(tris.Count);
        Debug.Log(polygons.Count);
    }

}
