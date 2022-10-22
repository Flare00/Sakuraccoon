using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Level nextLevel; // Niveau suivant, si dernier niveau, lance un script particulier.

    public void PlayerCollision(){

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelSystem.GetInstance().ChangeLevel(nextLevel);
        }
    }
}
