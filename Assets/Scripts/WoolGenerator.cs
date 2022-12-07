using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        List<int> triangleIndex = new List<int>();
        List<float> polySizes = new List<float>();

        vertices.AddRange(woolMesh.vertices);
        triangleIndex.AddRange(woolMesh.triangles);

        if(triangleIndex.Count%3 != 0) Debug.LogError("Incorrect vertices count!");

        List<Polygon> polygons = new List<Polygon>();

        for(int i=0;i<triangleIndex.Count;i=i+3){
            Vector3[] polyVertices={
                vertices[triangleIndex[i]], 
                vertices[triangleIndex[i+1]], 
                vertices[triangleIndex[i+2]]
            };

            polygons.Add(new Polygon(polyVertices));
        }

        foreach(Polygon polygon in polygons){
            Vector3 instantiatePos;
            instantiatePos = transform.TransformPoint(polygon.CenterPos);

            float polySize = polygon.Size;

            Instantiate(wool,instantiatePos,Quaternion.identity,this.transform);
            polySizes.Add(polySize);
        }
        Debug.Log("Num of Polygons:"+polygons.Count);
        Debug.Log("Max Size:"+polySizes.Max());
        Debug.Log("Min Size:"+polySizes.Min());

    }

}
