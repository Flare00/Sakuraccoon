using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDash : Card
{
    public override void DoAction(Player p, bool destroy = true){

        if (destroy)
            Destroy();
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Dash;
    }
}
