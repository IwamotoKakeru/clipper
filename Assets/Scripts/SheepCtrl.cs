using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepCtrl : MonoBehaviour
{
    private Renderer render;
    public int HP { get; private set; }

    void Start()
    {
        render = this.GetComponent<Renderer>();
        render.material.color = Color.black;
        HP = 10;
    }

    void Update()
    {
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("Hit Sheep");
        render.material.color = Color.red;
    }
}
