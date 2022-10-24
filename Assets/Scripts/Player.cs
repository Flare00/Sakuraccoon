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
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        psEffect = GetComponent<PSEffect>();
    }
    public void MoveLeftRight(float value)
    {
        if (CardDash.DASH_IN_EXECUTION > 0)
        {
            // Quand le dash est en cours d'exec
        }

        if (CardDash.DASH_IN_EXECUTION <= 0 && CardRoll.ROLL_IN_EXECUTION <= 0)
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
            rigid.velocity = new Vector2(value * 7.0f, rigid.velocity.y);
        }
    }

    public void CardPlayerAnim(Card.CardType type)
    {
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
