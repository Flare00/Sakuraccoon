using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    public static int NB_MAX_CARDS = 5;
    private Card[] cards = new Card[NB_MAX_CARDS];

    public Player player;

    public Level tmpLevel; //for test, to remove and implement LevelSystem


    public void PlayCard(int pos)
    {
        player.CardPlayerAnim(Card.CardType.Jump);
        /*if (pos >= 0 && pos < NB_MAX_CARDS)
        {
            if (cards[pos] != null)
            {
                if (player != null)
                {
                    player.CardPlayerAnim(cards[pos].GetCardType());
                }
                cards[pos].DoAction();
            }
        }*/
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
        tmpLevel.StartLevel();
    }

    private void Update()
    {
        
    }
}
