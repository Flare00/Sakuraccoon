using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraTextureScript : MonoBehaviour
{

    public RenderTexture RenderTex()
    {
        Camera cam = GetComponent<Camera>();
        RenderTexture rt = new RenderTexture(cam.pixelWidth, cam.pixelHeight, 24, RenderTextureFormat.RGB565 );
        cam.targetTexture = rt;
        cam.Render();
        cam.targetTexture = null;
        return rt;
    }


}
