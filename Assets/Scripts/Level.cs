using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level : MonoBehaviour
{
    [System.Serializable]
    public struct EnemyData
    {
        public Enemy.EnemyType type;
        public Vector2 position;
        public bool right;
    }

    public ActionSystem actionSystem;

    public int idLevel; // Numéro du niveau
    public LevelStart start; // Permet de savoir où spawn le joueur
    public float zoomLevel; // Définie le niveau de zoom du niveau, entre 0 et 1.

    public List<Card.CardType> cards; // Stocke les cartes par défaut au début du niveau.

    public bool unlimitedCard = false;
    public List<EnemyData> enemiesData;


    private List<Enemy> enemies;
    void Start()
    {
        enemies = new List<Enemy>();
    }

    public void StartLevel()
    {
        if (start != null)
        {
            actionSystem.player.transform.position = start.transform.position + new Vector3(0, 0.01f, 0);
            actionSystem.FillCards(cards, unlimitedCard);
            foreach(EnemyData e in enemiesData)
            {
                enemies.Add(Enemy.GenerateEnemyByType(e.type, this.transform, e.position, e.right, actionSystem));
            }
        }
    }

    public void StopLevel()
    {
        for(int i = enemies.Count-1; i >= 0; i--)
        {
            if (enemies[i] != null)
            {
                if(enemies[i].gameObject != null)
                {
                    Destroy(enemies[i].gameObject);
                }
                enemies[i] = null;
            }

            enemies.RemoveAt(i);
        }
    }



}
