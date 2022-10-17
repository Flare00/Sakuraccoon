using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{

    public GameObject cardGameObject;
    public enum CardType{
        Jump,
        Dash
    }

    public void Destroy()
    {
        if (cardGameObject != null)
        {
            GameObject.Destroy(cardGameObject);
            cardGameObject = null;
        }
    }

    public abstract void DoAction(Player p, bool destroy = true);

    public abstract CardType GetCardType();

    public static Card GenerateCardByType(CardType type)
    {
        Card card = null;
        string cardFileName = "";
        switch (type)
        {
            case Card.CardType.Jump:
                card = new CardJump();
                cardFileName = "CardJump";
                break;
            case Card.CardType.Dash:
                card = new CardDash();
                cardFileName = "CardDash";
                break;
        }
        if(card != null)
        {
            card.cardGameObject = GameObject.Instantiate(Resources.Load("Prefabs/Cards/" + cardFileName, typeof(GameObject))) as GameObject;
        }
        return card;
    }
}
