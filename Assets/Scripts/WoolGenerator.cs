using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolGenerator : MonoBehaviour
{
    public GameObject wool = null;
    private Mesh woolMesh = null;

    private float lowerRange = -0.5f,higherRange = 0.5f;
    private int numOfGeneratedWool = 1000;
    private Vector3 generatePos;

    void Start()
    {
        // RandomInstantiate();
        GenerateOnTheVertics();
        
    }

    void RandomInstantiate(){
        for(int i=0;i<numOfGeneratedWool;i++){
            float diffX = Random.Range(lowerRange,higherRange);
            float diffY = Random.Range(lowerRange,higherRange);
            float diffZ = Random.Range(lowerRange,higherRange);

            generatePos = this.transform.position +new Vector3(diffX,diffY,diffZ);

            Instantiate(wool,generatePos,Quaternion.identity);

        }
    }

    void GenerateOnTheVertics(){
        woolMesh = GetComponent<MeshFilter>().mesh;
        List<Vector3> vertices = new List<Vector3>();
        vertices.AddRange(woolMesh.vertices);
        Transform targetTransform = wool.transform;
        for(int i=0;i<vertices.Count;i++){
            vertices[i]= this.transform.TransformPoint(vertices[i]);
            Instantiate(wool,vertices[i],Quaternion.identity);
        }
    }


}
