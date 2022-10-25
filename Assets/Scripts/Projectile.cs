using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject emitter;
    public ActionSystem actionSystem;
    public void SetData(GameObject emitter, ActionSystem actionSystem = null)
    {
        this.emitter = emitter;
        this.actionSystem = actionSystem;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hit = false;


        if (other.gameObject != emitter && !other.CompareTag("Attack") && !other.CompareTag("Dialog"))
        {
            hit = true;
            if (emitter.CompareTag("Player") && other.CompareTag("Enemy"))
            {
                //Kill ennemy
                other.gameObject.GetComponent<Enemy>().Death();
            } else if (emitter.CompareTag("Enemy") && other.CompareTag("Player"))
            {
                //Kill player
                if (actionSystem != null)
                {
                    actionSystem.Death();
                }
            }
        } 


        if (hit)
        {
            Destroy(gameObject);
        }

    }
}
