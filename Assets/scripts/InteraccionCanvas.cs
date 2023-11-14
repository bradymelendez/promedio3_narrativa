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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            DesactivarCanvas();
        }
    }

    void ActivarCanvas()
    {
        canvasActivo = true;
        Time.timeScale = 0; 
        canvas.enabled = true; 
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }

    void DesactivarCanvas()
    {
        canvasActivo = false;
        Time.timeScale = 1; 
        canvas.enabled = false; 
        esperandoSegundaPulsacion = false;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 
    }
}
