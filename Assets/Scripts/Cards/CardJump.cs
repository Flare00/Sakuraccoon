using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardJump : Card
{

    public void DoAction(bool destroy = true){

    }

    public Card.CardType GetCardType()
    {
        return Card.CardType.Jump;
    }
}
