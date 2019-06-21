using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe: MonoBehaviour
{
    GameObject heroe;   
    void Start()
    {
        heroe = gameObject;
        heroe.name = "Heroe";
        heroe.AddComponent<Movimiento>();
        heroe.AddComponent<Rigidbody>();      
        heroe.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
