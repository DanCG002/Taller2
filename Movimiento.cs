using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Zombie z;
    Vector3 recorrer;
    Rigidbody obj;
    float velocidad = 8f;
    
    void Start()
    {
       obj = GetComponent<Rigidbody>();
    }    
    void Update()
    {
        float posH = Input.GetAxisRaw("Horizontal");
        float PosV = Input.GetAxisRaw("Vertical");
        Mov(posH, PosV);
        Rotacion();
    }

    public void Mov(float pHor, float pVer)
    {
        recorrer.Set(pHor, 0, pVer);
        recorrer = recorrer.normalized * Time.deltaTime * velocidad;
       obj.MovePosition(transform.position + recorrer);
    }

    public void Rotacion()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hitfloor;
        if (Physics.Raycast(camRay, out Hitfloor))
        {           
            Vector3 playerToMouse = Hitfloor.point - transform.position;
            playerToMouse.y = 0f;         
            Quaternion newRotacion = Quaternion.LookRotation(playerToMouse);
            obj.MoveRotation(newRotacion);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
         if(collision.collider.GetComponent<Aldeano>())
        {
            Aldeano c = collision.collider.GetComponent<Aldeano>();
            Debug.Log("Mi Nombre es :" + c.ObtenerCiudadanoInf().apodo + " y tengo " + c.ObtenerCiudadanoInf().años+" años");
        }
        if (collision.collider.GetComponent<Zombie>())
        {
            Zombie z = collision.collider.GetComponent<Zombie>();
            Debug.Log(" warrrrrrrr Soy un zombie y me gusta " + z.ObtenerZombieInfo().extremidad);
        }

    }
}


