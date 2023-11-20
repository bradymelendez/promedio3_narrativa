using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivar : MonoBehaviour
{
    public float tiempoDesactivacion = 2f;
    public GameObject algo;
    public float temporizador;

    void Start()
    {
        temporizador = tiempoDesactivacion;
    }

    void Update()
    {
        if (algo.activeSelf)
        {
            temporizador -= Time.deltaTime;
            if (temporizador <= 0f)
            {
                algo.SetActive(false);
                temporizador = tiempoDesactivacion;
            }
        }
    }
}
