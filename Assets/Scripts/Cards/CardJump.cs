using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CardJump : Card
{
    public override void DoAction(Player p,bool destroy = true){
        Rigidbody2D rigid = p.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 10.0f);
        }
        if (destroy)
            Destroy();
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Jump;
    }
}
