using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI;

    Rigidbody2D rigid;
    AudioSource aud;
    public AudioClip jumpSound;
    public AudioClip dashSound;
    public float direction = 1.0f;
    public AttackZone attackZone;
    private PSEffect psEffect;
    public Animator animator { get; private set; }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        psEffect = GetComponent<PSEffect>();
        animator = GetComponentInChildren<Animator>();
    }
    public void MoveLeftRight(float value)
    {
        if (CardDash.DASH_IN_EXECUTION <= 0 && CardRoll.ROLL_IN_EXECUTION <= 0 && !dialogUI.IsOpen)
        {
            float tmpDir = value > 0 ? 1.0f : (value < 0 ? -1.0f : direction);
            if ((tmpDir >= 0) != (direction >= 0))
            {
                direction = tmpDir;
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);

                if (psEffect != null)
                {
                    psEffect.Flip();
                }

            }
            if (Math.Abs(value) > 0.05f)
            {
                animator.SetBool("walk", true);
            } else
            {
                animator.SetBool("walk", false);
            }
            rigid.velocity = new Vector2(value * 7.0f, rigid.velocity.y);
        } else
        {
            animator.SetBool("walk", false);
        }
    }

    public void CardPlayerAnim(Card.CardType type)
    {
        animator.SetBool("walk", false);
        if (type == Card.CardType.Jump)
        {
            if (psEffect != null)
            {
                psEffect.AddEffect(PSEffect.EffectType.Jump);
            }
            if (aud)
            {
                aud.clip = jumpSound;
                aud.Play();
            }
        }
        else if (type == Card.CardType.Dash)
        {
            if (psEffect != null)
            {
                if (direction >= 0)
                {
                    psEffect.AddEffect(PSEffect.EffectType.Dash);
                }
                else
                {
                    psEffect.AddEffect(PSEffect.EffectType.Dash, false);
                }
            }
            if (aud)
            {
                aud.volume = ((float)Parametres.GetInstance().SoundVolume) / 100.0f;
                aud.clip = dashSound;
                aud.Play();
            }
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
        CardDash.DASH_IN_EXECUTION = 0;
        CardRoll.ROLL_IN_EXECUTION = 0;
        GetComponent<Rigidbody2D>().gravityScale = ActionSystem.GRAVITY_SCALE;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        direction = 1.0f;

        if (transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (psEffect != null)
        {
            psEffect.stopEveryParticle();
        }
        if (aud)
        {
            aud.Stop();
        }
    }

    /* UI FUNCTIONS */

    public DialogUI DialogUI => dialogUI;

    public IInteractable Interactable { get; set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // ?. : Interactable != null then call Interact()
            Interactable?.Interact(this);
        }

    }
}
