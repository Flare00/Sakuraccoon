using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public ActionSystem action;
    public void PlayerCollision()
    {
        action.Death();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCollision();
    }
}
