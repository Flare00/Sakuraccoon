using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Card 
{

    public GameObject cardGameObject;
    public enum CardType{
        None,
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

    public static CardType GetCardTypeByString(string s)
    {
        CardType retour = CardType.None;
        IEnumerable<CardType> cts = Enum.GetValues(typeof(CardType)).Cast<CardType>();
        for(int i = 0, max = cts.Count(); i < max && retour == CardType.None; i++ )
        {
            if (cts.ElementAt(i).ToString().Equals(s))
            {
                retour =  cts.ElementAt(i);
            }
        }
        return CardType.None;
    }
}
