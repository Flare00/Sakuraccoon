using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private static bool FirstLaunch = true;
    public MenuCameraTextureScript menuCameraTex;
    public Material textureMaterial;
    public AudioSource audioSource;
    public GameObject transitionGO;

    // Start is called before the first frame update
    void Start()
    {
        if (FirstLaunch)
        {
            transitionGO.SetActive(false);
            FirstLaunch = false;
        }
        Parametres.LoadParameters(audioSource);
        GameState.LoadGameStates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClicked()
    {
        StartCoroutine(LoadS("SampleScene"));
    }

    public void SettingsClicked()
    {
        Debug.Log("Settings");
        StartCoroutine(LoadS("OptionScene"));

    }

    public void QuitClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadS(string scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
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
