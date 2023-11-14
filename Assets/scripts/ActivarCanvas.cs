using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivarCanvas: MonoBehaviour
{
    public Canvas canvasParaActivar;

    void Start()
    {
        // Desactivar el Canvas al inicio del juego
        canvasParaActivar.gameObject.SetActive(false);
    }

    public void ActivarCanvasOnClick()
    {
        // Activar el Canvas cuando se hace clic en el botón
        canvasParaActivar.gameObject.SetActive(true);

        // Llamar al método DesactivarCanvas después de 5 segundos
        Invoke("DesactivarCanvas", 5f);
    }

    void DesactivarCanvas()
    {
        // Desactivar el Canvas después de 5 segundos
        canvasParaActivar.gameObject.SetActive(false);
    }
}
