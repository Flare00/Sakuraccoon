using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public ActionSystem actionSystem;

    public int idLevel; // Numéro du niveau
    public LevelStart start; // Permet de savoir où spawn le joueur
    public float zoomLevel; // Définie le niveau de zoom du niveau, entre 0 et 1.

    public List<Card.CardType> cards; // Stocke les cartes par défaut au début du niveau.

    public bool unlimitedCard = false;
    public List<Enemy> enemies;

    void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        if (start != null)
        {
            actionSystem.player.transform.position = start.transform.position + new Vector3(0, 0.01f, 0);
        }
    }

    

}
