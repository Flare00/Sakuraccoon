using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CardJump : Card
{
    private float jumpPower = 10.0f;
    public override void DoAction(Player p,bool destroy = true){
        Rigidbody2D rigid = p.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
        if (destroy)
            Destroy();
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Jump;
    }
}
