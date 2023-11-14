using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public GameObject objetoAActivar;
    public void ActivarObjetoDeseado()
    {
            objetoAActivar.SetActive(true);
    }
}
