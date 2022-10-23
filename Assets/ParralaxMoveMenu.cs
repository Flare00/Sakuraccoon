using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxMoveMenu : MonoBehaviour
{
    public float speed = 1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((speed * Time.deltaTime) + transform.position.x, 0, 0);
    }
}
