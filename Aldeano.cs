using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldeano : MonoBehaviour
{
    string mensaje;
    int edad;
    string nombres;
    public enum Nombres
    {
      Fred,Carlos,Jeremy,Annie,Carmen,Andres,Canela,Robin,
      Arturo,Otoniel,Robert,Fausto,Javier,Hernan,Larry,Gregorio,Zac,
      Victor,Rosa,Daniela
    }

    public struct Info_Aldeano
    {
       public int años;
       public string apodo;
    }
    GameObject cubo;
    public void Start()
    {
        cubo = gameObject;
        cubo.GetComponent<Renderer>().material.color = Color.magenta;
        cubo.name = "Aldeano";
        nombres = ((Nombres)Random.Range(0, 20)).ToString();
        edad = Random.Range(15, 100);
        cubo.transform.position = new Vector3(Random.Range(-25, 20), 0.4f, Random.Range(-20, 20));
        cubo.AddComponent<Rigidbody>();
    }

    public Info_Aldeano ObtenerCiudadanoInf()
    {
        Info_Aldeano dato = new Info_Aldeano();
        Info_Aldeano.años = años;
        Info_Aldeano.apodo = apodo;
        return dato;



    }

}
