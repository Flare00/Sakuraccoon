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

    public static void LoadParameters()
    {
        GetInstance().MusicVolume = PlayerPrefs.GetInt("Music",100);
        GetInstance().SoundVolume = PlayerPrefs.GetInt("Sound", 100);
    }

    public static void SaveParameters()
    {
        PlayerPrefs.SetInt("Music", GetInstance().MusicVolume);
        PlayerPrefs.SetInt("Sound", GetInstance().SoundVolume);
        PlayerPrefs.Save();
    }
}
