using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolGenerator : MonoBehaviour
{
    public GameObject wool = null;

    private float lowerRange = -0.5f,higherRange = 0.5f;
    private int numOfGeneratedWool = 100;
    private Vector3 generatePos;

    void Start()
    {
        RandomInstantiate();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("wool")){

        }      
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

}
