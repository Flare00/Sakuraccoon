using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Card 
{

    public GameObject cardGameObject;
    public enum CardType{
        None,
        Jump,
        Dash,
        Dig,
        CasseNoisette,
        Climb,
        Baseball,
        Roll
    }

    public void Destroy()
    {
        if (cardGameObject != null)
        {
            GameObject.Destroy(cardGameObject);
            cardGameObject = null;
        }
    }

    public abstract bool DoAction(Player p, bool destroy = true); // return if action has be done

    public abstract CardType GetCardType();

    public static Card GenerateCardByType(CardType type, ActionSystem actionSystem)
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
            case Card.CardType.Dig:
                card = new CardDig();
                cardFileName = "CardDig";
                break;
            case Card.CardType.CasseNoisette:
                card = new CardCasseNoisette();
                cardFileName = "CardCasseNoisette";
                break;
            case Card.CardType.Roll:
                card = new CardRoll();
                cardFileName = "CardRoll";
                break;
            case Card.CardType.Climb:
                card = new CardClimb();
                cardFileName = "CardClimb";
                break;
            case Card.CardType.Baseball:
                card = new CardBaseball();
                cardFileName = "CardBaseball";
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
