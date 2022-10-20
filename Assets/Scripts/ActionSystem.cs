using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    public static float GRAVITY_SCALE = 3.0f;
    public static int NB_MAX_CARDS = 5;
    private Card[] cards = new Card[NB_MAX_CARDS];
    private bool unlimited = false;
    public Player player;
    public GameState gameState;
    private AudioSource audioSource;
    public AudioClip deathSound;

    public GameObject cardsAnchorParent;

    private GameObject[] cardsAnchor;

    private void Start()
    {
        if (cardsAnchorParent != null)
        {
            cardsAnchor = new GameObject[NB_MAX_CARDS];
            for (int i = 0; i < NB_MAX_CARDS; i++)
            {
                cardsAnchor[i] = cardsAnchorParent.transform.GetChild(i).gameObject;
            }
        }
        GRAVITY_SCALE = player.GetComponent<Rigidbody2D>().gravityScale;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCard(int pos)
    {
        if (pos >= 0 && pos < NB_MAX_CARDS)
        {
            if (cards[pos] != null)
            {
                if (player != null)
                {
                    player.CardPlayerAnim(cards[pos].GetCardType());
                }
                cards[pos].DoAction(player, !unlimited);
                if (!unlimited)
                {
                    cards[pos] = null;
                }
            }
        }
    }

    public void Move(Vector2 axis)
    {
        if (player != null)
        {
            player.MoveLeftRight(axis.x);
        }
    }

    public void Death()
    {
        for (int i = 0; i < NB_MAX_CARDS; i++)
        {
            if (cards[i] != null)
            {
                if (audioSource)
                {
                    audioSource.clip = deathSound;
                    audioSource.Play();
                }
                cards[i].Destroy();
            }
        }
        StopPlayer();
        gameState.IncrementDeath();
        LevelSystem.GetInstance().RestartLevel();
    }

    public void StopPlayer()
    {
        player.StopAllCoroutines();
        CardDash.DASH_IN_EXECUTION = 0;
        player.GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.direction = 1.0f;
    }

    public void FillCards(List<Card.CardType> list, bool unlimited)
    {
        this.unlimited = unlimited;
        for (int i = 0; i < NB_MAX_CARDS; i++)
        {
            if (this.cards[i] != null)
            {
                this.cards[i].Destroy();

                this.cards[i] = null;
            }
        }
        for (int i = 0, max = list.Count; i < max && i < NB_MAX_CARDS; i++)
        {
            this.cards[i] = Card.GenerateCardByType(list[i]);
            this.cards[i].cardGameObject.transform.SetParent(cardsAnchor[i].transform, false);
            //this.cards[i].cardGameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {

    }
}
