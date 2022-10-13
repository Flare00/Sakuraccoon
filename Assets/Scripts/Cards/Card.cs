using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Card 
{
    public enum CardType{
        Jump,
        Dash
    }

    public void DoAction(bool destroy = true);

    public CardType GetCardType();
}
