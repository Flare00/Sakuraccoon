using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;

    private void Start()
    {
        musicSlider.value = Parametres.GetInstance().MusicVolume;
        soundSlider.value = Parametres.GetInstance().SoundVolume;
    }
    public void Retour()
    {

    }

    public void MusicChange()
    {
        Parametres.GetInstance().MusicVolume = (int)musicSlider.value;
        Parametres.SaveParameters();
    }

    public void SoundChange()
    {
        Parametres.GetInstance().MusicVolume = (int)musicSlider.value;
        Parametres.SaveParameters();
    }


}
