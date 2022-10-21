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
        GetInstance().MusicVolume = 50;
        GetInstance().SoundVolume = 50;
    }

    public static void SaveParameters()
    {

    }
}
