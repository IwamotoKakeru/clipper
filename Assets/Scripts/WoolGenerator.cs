using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Polygon
{
    private Vector3[] polyVertices = new Vector3[3];
    public Vector3[] PolyVertices
    {
        get => polyVertices;
    }

    public Vector3 CrossVector { get; private set; }
    public float Size { get; private set; }
    public Vector3 CenterPos { get; private set; }

    public Polygon(Vector3[] recPolyVertices)
    {
        polyVertices = recPolyVertices;

        CrossVector = Vector3.Cross(
            polyVertices[1] - polyVertices[0],
            polyVertices[2] - polyVertices[0]
        );

        Size = CrossVector.magnitude / 2;

        CenterPos = (polyVertices[0] + polyVertices[1] + polyVertices[2]) / 3;
    }

    public Vector3 GetRandomSurfacePos()
    {
        //空間ベクトルの点の存在範囲より三角形上のランダムな座標を得る
        Vector3 RandomSurfacePos;

        float s = Random.value;
        float t = Random.value;

        if (s + t > 1f)
        {
            s = 1f - s;
            t = 1f - t;
        }
        float u = 1f - s - t;

        RandomSurfacePos = s * polyVertices[0] + t * polyVertices[1] + u * polyVertices[2];

        return RandomSurfacePos;
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

    void GenerateOnPlane()
    {
        woolMesh = GetComponent<MeshFilter>().mesh;

        List<Vector3> vertices = new List<Vector3>();
        List<int> verticesIndex = new List<int>();
        List<float> polySizes = new List<float>();

        vertices.AddRange(woolMesh.vertices);
        verticesIndex.AddRange(woolMesh.triangles);

        if (verticesIndex.Count % 3 != 0) Debug.LogError("Incorrect vertices count!");

        List<Polygon> polygons = new List<Polygon>();

        for (int i = 0; i < verticesIndex.Count; i = i + 3)
        {

            Vector3[] polyVertices ={
                vertices[verticesIndex[i]],
                vertices[verticesIndex[i+1]],
                vertices[verticesIndex[i+2]]
            };

            polygons.Add(new Polygon(polyVertices));
        }

        foreach (Polygon polygon in polygons)
        {
            polySizes.Add(polygon.Size);
        }

        foreach (Polygon polygon in polygons)
        {
            Vector3 instantiatePos;
            int sizeMultiple = (int)(polygon.Size / polySizes.Min());

            // if (sizeMultiple > 1)
            if (false)
            {
                for (int i = 0; i < sizeMultiple; i++)
                {
                    instantiatePos = transform.TransformPoint(polygon.GetRandomSurfacePos());
                    Instantiate(wool, instantiatePos, Quaternion.identity, this.transform);
                }
            }
            else
            {
                instantiatePos = transform.TransformPoint(polygon.CenterPos);
                Instantiate(wool, instantiatePos, Quaternion.identity, this.transform);
            }

        }

        Debug.Log("Num of Polygons:" + polygons.Count);
        Debug.Log("Max Size:" + polySizes.Max());
        Debug.Log("Min Size:" + polySizes.Min());

    }

}
