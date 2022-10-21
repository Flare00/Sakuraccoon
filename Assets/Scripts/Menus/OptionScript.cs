using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
    public MenuCameraTextureScript menuCameraTex;
    public Material textureMaterial;
    public ActionSystem actionSystem;

    public Slider musicSlider;
    public TextMeshProUGUI musicValue;
    public Slider soundSlider;
    public TextMeshProUGUI soundValue;

    private void Start()
    {
        Parametres.LoadParameters();
        musicSlider.value = Parametres.GetInstance().MusicVolume;
        musicValue.text = "" + Parametres.GetInstance().MusicVolume;
        soundSlider.value = Parametres.GetInstance().SoundVolume;
        soundValue.text = "" + Parametres.GetInstance().SoundVolume;
    }

    public void MainMenu()
    {
        StartCoroutine(LoadS("MainMenuScene"));
    }

    public void Resume()
    {
        if(actionSystem != null)
        {
            actionSystem.TogglePause();
        }
    }

    public void MusicChange()
    {
        Parametres.GetInstance().MusicVolume = (int)musicSlider.value;
        musicValue.text = "" + Parametres.GetInstance().MusicVolume;
        Parametres.SaveParameters();
    }

    public void SoundChange()
    {
        Parametres.GetInstance().SoundVolume = (int)soundSlider.value;
        soundValue.text = "" + Parametres.GetInstance().SoundVolume;
        Parametres.SaveParameters();
    }

    IEnumerator LoadS(string scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            Debug.Log("Progress : " + asyncOperation.progress);
            if (asyncOperation.progress >= 0.9f)
            {
                RenderTexture tex = menuCameraTex.RenderTex();
                textureMaterial.SetTexture("_BaseMap", tex);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
