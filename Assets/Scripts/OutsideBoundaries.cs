using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBoundaries : MonoBehaviour
{

    public ActionSystem action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            action.Death();
        } else if (other.CompareTag("Enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            e.StartCoroutine(e.WaitAndDeath());
        }
    }
}
