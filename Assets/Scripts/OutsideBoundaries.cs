using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBoundaries : MonoBehaviour
{

    public ActionSystem action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Outside Boundaries");
        action.Death();
    }
}
