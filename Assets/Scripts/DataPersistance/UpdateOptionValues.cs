using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateOptionValues : MonoBehaviour
{
    public AudioSource audioS;
    public Slider volumeSlider;


    public void ValueChangeCheck()
    {
        audioS.volume = volumeSlider.value;
    }

    private void Update()
    {
        volumeSlider.value = audioS.volume;
    }
}
