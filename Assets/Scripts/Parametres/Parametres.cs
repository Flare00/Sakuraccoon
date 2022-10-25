using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametres 
{
    public static string filePath = ""; // Le chemin du fichier.
    private static Parametres instance;
    public static Parametres GetInstance()
    {
        if(instance == null)
        {
            instance = new Parametres();
        }
        return instance;
    }

    public int MusicVolume { get; set; }
    public int SoundVolume { get; set; }

    public static void LoadParameters(AudioSource musicSource = null)
    {
        GetInstance().MusicVolume = PlayerPrefs.GetInt("Music", 10);
        GetInstance().SoundVolume = PlayerPrefs.GetInt("Sound", 10);
        if (musicSource)
        {
            musicSource.volume = ((float)GetInstance().MusicVolume) / 100.0f;
        }
    }

    public static void SaveParameters()
    {
        PlayerPrefs.SetInt("Music", GetInstance().MusicVolume);
        PlayerPrefs.SetInt("Sound", GetInstance().SoundVolume);
        PlayerPrefs.Save();
    }
}
