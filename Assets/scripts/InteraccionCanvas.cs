using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionCanvas : MonoBehaviour
{
    public Canvas canvas;
    private bool dentroDelColisionador = false;
    private bool canvasActivo = false;
    private bool esperandoSegundaPulsacion = false;

    void Start()
    {
        canvas.enabled = false;
        Cursor.visible = false; // Al inicio, se oculta el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro de la pantalla
    }

    void Update()
    {
        if (dentroDelColisionador && Input.GetKeyDown(KeyCode.E))
        {
            if (canvasActivo)
            {
                if (esperandoSegundaPulsacion)
                {
                    DesactivarCanvas();
                    esperandoSegundaPulsacion = false;
                }
                else
                {
                    esperandoSegundaPulsacion = true;
                }
            }
            else
            {
                ActivarCanvas();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dentroDelColisionador = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dentroDelColisionador = false;
            DesactivarCanvas();
        }
    }

    void ActivarCanvas()
    {
        canvasActivo = true;
        Time.timeScale = 0; // Pausar el juego
        canvas.enabled = true; // Mostrar el Canvas
        Cursor.visible = true; // Muestra el cursor
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
    }

    void DesactivarCanvas()
    {
        canvasActivo = false;
        Time.timeScale = 1; // Reanudar el juego
        canvas.enabled = false; // Ocultar el Canvas
        esperandoSegundaPulsacion = false;
        Cursor.visible = false; // Oculta el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
    }
}
