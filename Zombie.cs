using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie:MonoBehaviour
{   
    string mensaje;
    bool Encendido = true;
    float distancia;
    int est_Ahora;
    Vector3 meta;
    GameObject cubo;
    public enum Estados
    {
        quieto, moverse
    }
    Estados estado_zombie;

    public enum Partes_Corporales
    {
        Cabeza, pecho, Muslos, Brazos, Piernas
    }

    Partes_Corporales partes;
    public struct infoZombie
    {
        public Color color;
        public Partes_Corporales extremidad;

    }
   
    public void Start()
    {
        cubo = gameObject;
        int elige_Color = Random.Range(0, 3);
        switch(elige_Color)
        {
            case 0:
                cubo.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 1:
                cubo.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 2:
                cubo.GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
       
        cubo.transform.position = new Vector3(Random.Range(-15, 25), 0.4f, Random.Range(-25, 26));       
        cubo.AddComponent<Rigidbody>();
        cubo.name = "Zombie";
        
        if (Encendido)
        {
            StartCoroutine(estado_Zomb());
        }

        else if (Encendido == false)
        {
            StopCoroutine(estado_Zomb());
        }


    }

    public infoZombie ObtenerZombieInfo()
    {
        infoZombie dato = new infoZombie();        
        int parte = Random.Range(0, 4);
        switch (parte)
        {
            case 0:
                dato.extremidad = Partes_Corporales.pecho;
                mensaje = "Warrrrr soy un zombie y quiero comer " + dato.extremidad;
                break;
            case 1:
                dato.extremidad = Partes_Corporales.Piernas;
                mensaje = "Warrrrrr soy un Zombie y quiero comer " + dato.extremidad;
                break;
            case 2:
                dato.extremidad = Partes_Corporales.Muslos;
                mensaje = "Warrrrr soy un zombie y quiero comer " + dato.extremidad;
                break;
            case 3:
                dato.extremidad = Partes_Corporales.Brazos;
                mensaje = "Warrrrr soy un zombie y quiero comer " + dato.extremidad;
                break;
            case 4:
                dato.extremidad = Partes_Corporales.Cabeza;
                mensaje = "Warrrrr soy un zombie y quiero comer" + dato.extremidad;
                break;
        }
        return dato;
    }

     void Update()
    {
       
        if (estado_zombie == Estados.moverse)
        {
            transform.Translate(meta * Time.deltaTime*0.3f);
        }
        if (estado_zombie == Estados.quieto)
        {
            Debug.Log("No me muevo");
        }

    }

    public IEnumerator estado_Zomb()
    {

        estado_zombie = (Estados)Random.Range(0, 2);
        
        if (estado_zombie == Estados.moverse)
        {
            meta = new Vector3(Random.Range(-15, 15), 0f, Random.Range(-15, 15) );
            yield return null;

        }    
        yield return new WaitForSeconds(5f);
        yield return estado_Zomb();
    }  
}

