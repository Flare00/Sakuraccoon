using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScaler : MonoBehaviour
{
    private const float RATIO_DELTA = 0.001f;
    private Camera cameraElem;
    // Start is called before the first frame update
    void Start()
    {
        cameraElem = gameObject.GetComponent<Camera>();
        ScreenRatioChange();
    }

    // Update is called once per frame
    void Update()
    {
       // ScreenRatioChange();
    }

    private bool inAspect(float ratio, float aspectX, float aspectY){
        float aspect = aspectX/aspectY;
        return ratio > (aspect - RATIO_DELTA) && ratio < (aspect + RATIO_DELTA);
    }

    public void ScreenRatioChange(){
        if(cameraElem != null){
            float ratio = cameraElem.aspect;
            if(inAspect(ratio,4,3)){
                cameraElem.orthographicSize = 6.3f;
            } else if (inAspect(ratio,16,9)){
                cameraElem.orthographicSize = 5.4f;
            } else if (inAspect(ratio,16,10)){
                cameraElem.orthographicSize = 5.4f;
            }
        }
    }
}
