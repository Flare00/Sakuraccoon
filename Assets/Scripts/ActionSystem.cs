using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    public static int NB_MAX_CARDS = 5;
    private Card[] cards = new Card[NB_MAX_CARDS];

    public Player player;

    public void PlayCard(int pos)
    {
        if (pos >= 0 && pos < NB_MAX_CARDS)
        {
            if (cards[pos] != null)
                if(player != null)
                {
                    player.CardPlayerAnim(cards[pos].GetCardType());
                }
                cards[pos].DoAction();
        }
    }

    public void Move(Vector2 axis)
    {
        if (player != null)
        {
            player.MoveLeftRight(axis.x);
        }
    }
}
