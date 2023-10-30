using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

