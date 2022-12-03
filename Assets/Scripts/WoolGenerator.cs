﻿using System.Collections;
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

    private float lowerRange = -0.5f,higherRange = 0.5f;
    private int numOfGeneratedWool = 1000;
    private Vector3 generatePos;

    void Start()
    {
        GenerateOnPlane();
    }

    void RandomInstantiate(){
        for(int i=0;i<numOfGeneratedWool;i++){
            float diffX = Random.Range(lowerRange,higherRange);
            float diffY = Random.Range(lowerRange,higherRange);
            float diffZ = Random.Range(lowerRange,higherRange);

            generatePos = this.transform.position +new Vector3(diffX,diffY,diffZ);

            Instantiate(wool,generatePos,Quaternion.identity,this.transform);

        }
    }

    void GenerateOnTheVertics(){
        woolMesh = GetComponent<MeshFilter>().mesh;
        List<Vector3> vertices = new List<Vector3>();
        vertices.AddRange(woolMesh.vertices);
        Transform targetTransform = wool.transform;
        for(int i=0;i<vertices.Count;i++){
            vertices[i]= this.transform.TransformPoint(vertices[i]);
            Instantiate(wool,vertices[i],Quaternion.identity,this.transform);
        }

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

        Debug.Log(vertices.Count);
        Debug.Log(tris.Count);
        Debug.Log(polygons.Count);
    }


}
