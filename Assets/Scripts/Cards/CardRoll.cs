using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRoll : Card
{
    public static Vector2 BOX_COLLIDER_SIZE = new Vector2(0.9f, 0.9f);
    public static Vector2 BOX_COLLIDER_OFFSET = new Vector2(0, -0.05f);
    public static int ROLL_IN_EXECUTION = 0;
    private float rollForce = 30.0f;
    private float rollDuration = 0.2f;

    public override bool DoAction(Player p, bool destroy = true){
        Rigidbody2D rigid = p.GetComponent<Rigidbody2D>();
        p.StartCoroutine(RollHandler(p));
        if (destroy)
            Destroy();
        return true;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Roll;
    }

    IEnumerator RollHandler(Player p)
    {
        p.animator.SetBool("roll", true);
        Rigidbody2D rigid = p.GetComponent<Rigidbody2D>();
        ROLL_IN_EXECUTION++;
        if(ROLL_IN_EXECUTION == 1)
        {
            ReduceSizeForRoll(p);
        }
        rigid.position += new Vector2(0, 0.1f);
        rigid.velocity = new Vector2(p.direction, 0f);
        rigid.AddForce(new Vector2(rollForce * p.direction, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(rollDuration);
        ROLL_IN_EXECUTION--;
        if(ROLL_IN_EXECUTION <= 0)
        {
            rigid.velocity = new Vector2(0f, 0f);
            Reset(p);
            p.animator.SetBool("roll", false);
        }
    }

    private static void ReduceSizeForRoll(Player p)
    {
        BoxCollider2D bc = p.GetComponent<BoxCollider2D>();
        BOX_COLLIDER_SIZE = bc.size;
        BOX_COLLIDER_OFFSET = bc.offset;
        bc.size = new Vector2(0.4f, 0.4f);
        bc.offset  = new Vector2(0, -0.3f);
    }

    public static void Reset(Player p)
    {
        ROLL_IN_EXECUTION = 0;
        BoxCollider2D bc = p.GetComponent<BoxCollider2D>();
        bc.size = BOX_COLLIDER_SIZE;
        bc.offset = BOX_COLLIDER_OFFSET;
    }
}
