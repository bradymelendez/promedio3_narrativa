using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vidaInicial = 100f;
    public float vidaActual;
    public float da�oRecibido = 20;
    public Transform jugador;
    public float rangoDeSeguimiento = 10f;
    public float velocidad = 5f;
    public float tiempoEntreGolpes = 2f;
    public float distanciaRetroceso = 2f; // Distancia de retroceso cuando toca al jugador
    private bool puedeHacerDa�o = true;
    private bool retrocediendo = false; // Variable para controlar si el enemigo est� retrocediendo

    void Start()
    {
        vidaActual = vidaInicial;
    }

    void Update()
    {
        if (!retrocediendo)
        {
            SeguirJugador();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Roca"))
        {
            RecibirDanio(da�oRecibido);
        }
        else if (other.CompareTag("Player") && puedeHacerDa�o)
        {
            Retroceder();
            // Inicia el temporizador
            StartCoroutine(ActivarTemporizador());
        }
    }

    public void RecibirDanio(float cantidadDanio)
    {
        vidaActual -= cantidadDanio;

        if (vidaActual <= 0)
        {
            Morir();
        }

        if (puedeHacerDa�o)
        {
            // Aplica el da�o al jugador
            // Agrega aqu� tu l�gica para causar da�o al jugador

            // Inicia el temporizador
            StartCoroutine(ActivarTemporizador());
        }
    }

    void Morir()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject);
    }

    void SeguirJugador()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaAlJugador <= rangoDeSeguimiento)
        {
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;
            transform.Translate(direccionAlJugador * velocidad * Time.deltaTime);
        }
    }

    void Retroceder()
    {
        retrocediendo = true;
        Vector3 direccionRetroceso = (transform.position - jugador.position).normalized;
        transform.Translate(direccionRetroceso * distanciaRetroceso);
    }

    // Corrutina para activar el temporizador
    IEnumerator ActivarTemporizador()
    {
        // Desactiva la posibilidad de hacer da�o
        puedeHacerDa�o = false;

        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempoEntreGolpes);

        // Activa la posibilidad de hacer da�o nuevamente
        puedeHacerDa�o = true;

        // Reinicia la variable de retroceso
        retrocediendo = false;
    }

    // M�todo para visualizar el rango de seguimiento en el Editor de Unity
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeSeguimiento);
    }
}

