using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    AudioSource aud;
    public List<AudioClip> clips;
    public float direction = 1.0f;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        // clips.Add(new AudioClip);
    }
    public void MoveLeftRight(float value)
    {
        if (CardDash.DASH_IN_EXECUTION <= 0)
        {
            direction = value > 0 ? 1.0f : (value < 0 ? -1.0f : direction);
            rigid.velocity = new Vector2(value * 7.0f, rigid.velocity.y);
        }
    }

    public void CardPlayerAnim(Card.CardType type)
    {
        if (type == Card.CardType.Jump)
        {
            if (aud)
            {
                aud.clip = clips[0];
                aud.Play();
            }
        }
    }
}
