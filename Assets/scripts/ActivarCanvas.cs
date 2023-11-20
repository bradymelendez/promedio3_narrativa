using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivarCanvas: MonoBehaviour
{
    public Canvas canvasParaActivar;
    public float time;
    void Start()
    {
        // Desactivar el Canvas al inicio del juego
        canvasParaActivar.gameObject.SetActive(false);
    }

    public void ActivarCanvasOnClick()
    {
        // Activar el Canvas cuando se hace clic en el bot�n
        canvasParaActivar.gameObject.SetActive(true);

        // Llamar al m�todo DesactivarCanvas despu�s de 5 segundos
        Invoke("DesactivarCanvas", time);
    }

    void DesactivarCanvas()
    {
        // Desactivar el Canvas despu�s de 5 segundos
        canvasParaActivar.gameObject.SetActive(false);
    }
}
