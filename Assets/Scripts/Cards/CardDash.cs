using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDash : Card
{
    public static int DASH_IN_EXECUTION = 0;
    private float dashDistance = 30.0f;
    private float dashDuration = 0.2f;

    public override bool DoAction(Player p, bool destroy = true){
        Rigidbody2D rigid = p.GetComponent<Rigidbody2D>();
        p.StartCoroutine(DashHandler(p));
        if (destroy)
            Destroy();
        return true;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Dash;
    }

    IEnumerator DashHandler(Player p)
    {
        Rigidbody2D rigid = p.GetComponent<Rigidbody2D>();
        DASH_IN_EXECUTION++;
        rigid.velocity = new Vector2(p.direction, 0f);
        rigid.AddForce(new Vector2(dashDistance * p.direction, 0f), ForceMode2D.Impulse);
        rigid.gravityScale = 0f;
        yield return new WaitForSeconds(dashDuration);
        DASH_IN_EXECUTION--;
        if(DASH_IN_EXECUTION <= 0)
        {
            rigid.gravityScale = ActionSystem.GRAVITY_SCALE;
            rigid.velocity = new Vector2(0f, 0f);
        }
    }
}
