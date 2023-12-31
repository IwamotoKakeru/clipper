using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WoolGenerator : MonoBehaviour
{
    public GameObject wool = null;
    private Mesh woolMesh = null;

    void Awake()
    {
        GenerateOnPlane();
    }

    void GenerateOnPlane()
    {
        woolMesh = GetComponent<MeshFilter>().mesh;

        List<Vector3> vertices = new List<Vector3>();
        List<int> verticesIndex = new List<int>();
        List<float> polySizes = new List<float>();

        int timesOfGenerate = 10;
        int num = 0;

        vertices.AddRange(woolMesh.vertices);
        verticesIndex.AddRange(woolMesh.triangles);

        if (verticesIndex.Count % 3 != 0) Debug.LogError("Incorrect vertices count!");

        List<Polygon> polygons = new List<Polygon>();

        // 3つの頂点ごとにポリゴンインスタンスの生成を行う
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

            if ((num % timesOfGenerate) == 0)
            {
                instantiatePos = transform.TransformPoint(polygon.GetRandomSurfacePos());
                Instantiate(wool, instantiatePos, Quaternion.identity, this.transform);
            }
            num++;

        }

        Debug.Log("Num of Polygons:" + polygons.Count);
        Debug.Log("Max Size:" + polySizes.Max());
        Debug.Log("Min Size:" + polySizes.Min());

    }

}
