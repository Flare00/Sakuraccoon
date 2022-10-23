using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CardBaseball : Card
{
    private float jumpPower = 15.0f;
    public override bool DoAction(Player p,bool destroy = true){
       
        return true;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Jump;
    }
}
