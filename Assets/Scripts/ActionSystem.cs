using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    public static int NB_MAX_CARDS = 5;
    private Card[] cards = new Card[NB_MAX_CARDS];
    private bool unlimited = false;
    public Player player;
    public GameState gameState;
    public Level tmpLevel; //for test, to remove and implement LevelSystem

    public GameObject cardsAnchorParent;

    private GameObject[] cardsAnchor;

    private void Start()
    {
        if(cardsAnchorParent != null)
        {
            cardsAnchor = new GameObject[NB_MAX_CARDS];
            for(int i = 0; i < NB_MAX_CARDS; i++)
            {
                cardsAnchor[i] = cardsAnchorParent.transform.GetChild(i).gameObject;
            }
        }   
    }

    public void PlayCard(int pos)
    {
        if (pos >= 0 && pos < NB_MAX_CARDS)
        {
            if (cards[pos] != null)
            {
                if (player != null)
                {
                    player.CardPlayerAnim(cards[pos].GetCardType());
                }
                cards[pos].DoAction(player, !unlimited);
                if (!unlimited)
                {
                    cards[pos] = null;
                }
            }
        }
    }

    public void Move(Vector2 axis)
    {
        if (player != null)
        {
            player.MoveLeftRight(axis.x);
        }
    }

    public void Death()
    {
        for(int i = 0; i < NB_MAX_CARDS; i++)
        {
            if (cards[i] != null)
            {
                cards[i].Destroy();
            }
        }
        gameState.IncrementDeath();
        tmpLevel.StartLevel();
        
    }

    public void FillCards(List<Card.CardType> list, bool unlimited)
    {
        for (int i = 0, max = list.Count; i < max && i < NB_MAX_CARDS; i++)
        {
            this.cards[i] = Card.GenerateCardByType(list[i]);
            this.cards[i].cardGameObject.transform.SetParent(cardsAnchor[i].transform, false);
            //this.cards[i].cardGameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {

    }
}
