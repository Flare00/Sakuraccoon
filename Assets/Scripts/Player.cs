using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void MoveLeftRight(float value)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(value * 7.0f, rigid.velocity.y);
    }

    public void CardPlayerAnim(Card.CardType type)
    {
        if(type == Card.CardType.Jump)
        {
            Debug.Log("Jump");
            rigid.velocity = new Vector2(rigid.velocity.x, 10.0f);
        }
    }
}
