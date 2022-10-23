using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ParralaxMoveMenu : MonoBehaviour
{
    public float speed = 1.0f;
    private bool right = true;
    private float limit = 25;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((speed * Time.deltaTime * (right ? 1.0f : -1.0f)) + transform.position.x, 0, 0);
        if(transform.position.x > limit)
        {
            right = false;
        } else if (transform.position.x < -limit)
        {
            right = true;
        }
    }
}
