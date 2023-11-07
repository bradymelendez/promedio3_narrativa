using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController: MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    void Start()
    {
        canvas1.enabled = false;
        canvas2.enabled = true;
    }

    public void ActivarCanvas1()
    {
        canvas1.enabled = true;
        canvas2.enabled = false;
    }

    public void ActivarCanvas2()
    {
        canvas1.enabled = false;
        canvas2.enabled = true;
    }
}
