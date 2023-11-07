using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vidaInicial = 100f;
    public float vidaActual;
    public float dañorecibido = 20;


    void Start()
    {
        vidaActual = vidaInicial;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Roca"))
        {
            RecibirDanio(dañorecibido);
        }
    }
    public void RecibirDanio(float cantidadDanio)
    {
        vidaActual -= cantidadDanio;

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject);
    }
}
