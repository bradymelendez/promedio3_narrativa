using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    public Image Imagemute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenaudio", 0.5f);
        AudioListener.volume = slider.value;
        Revisarsiestoymute();
    }
    public void ChangeSlider(float valor)
    {
        slidervalue = valor;
        PlayerPrefs.SetFloat("volumenaudio", slidervalue);
        AudioListener.volume = slider.value;
        Revisarsiestoymute();
    }
    public void Revisarsiestoymute()
    {
        if(slidervalue==0)
        {
            Imagemute.enabled = true;
        }
        else
        {
            Imagemute.enabled = false;
        }
    }
}
