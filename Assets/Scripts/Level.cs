using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int idLevel; // Numéro du niveau
    public LevelStart start; // Permet de savoir où spawn le joueur
    public float zoomLevel; // Définie le niveau de zoom du niveau, entre 0 et 1.

    public List<Card.CardType> cards; // Stocke les cartes par défaut au début du niveau.

    public bool unlimitedCard = false;
    public List<Enemy> enemies;

    void Start() {
    }    

}   
