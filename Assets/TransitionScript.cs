using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    private float alpha = 1.0f;
    public float duration = 1.0f;
    public Material material;
    private float totalDuration = 0.0f;
    private bool hidden = false;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            first = false; //attend une frame pour evité un trop grand saut en deltatime.
        } else if (!hidden) {
            totalDuration += Time.deltaTime;
            // Utiliser une sigmoide ?
            alpha = 1.0f - (totalDuration / duration);
            material.color = new Color(1, 1, 1, alpha);
            if(totalDuration >= duration)
            {
                hidden = true;
                material.color = new Color(1, 1, 1, 1); //remet le material à son état par défaut, pour les prochaine execution.
                //Desactive l'objet et donc le script.
                gameObject.SetActive(false);
            }
        }
    }
}
