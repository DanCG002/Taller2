using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudad : MonoBehaviour
{    
    GameObject heroe;
    GameObject cube;

    void Start()
    {
        heroe = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        heroe.AddComponent<Heroe>();
       
        for(int i = 0; i < 11; i++)
        {
            int escoge = Random.Range(0, 2);
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (escoge == 0)
            {
                cube.AddComponent<Aldeano>();
            }

            if (escoge == 1)
            {
                cube.AddComponent<Zombie>();
            }
                      
        }
    }  
}
