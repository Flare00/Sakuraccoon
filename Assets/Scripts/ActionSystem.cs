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
    public GameObject pauseGO;
    private AudioSource audioSource;
    public AudioClip deathSound;

    public GameObject cardsAnchorParent;

    private GameObject[] cardsAnchor;
    private bool pause = false;

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
        if (pos >= 0 && pos < NB_MAX_CARDS && !pause)
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
        if (player != null && !pause)
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
        GameState.GetInstance().IncrementDeath();
        LevelSystem.GetInstance().RestartLevel();
    }

    public void StopPlayer()
    {
        player.Stop();
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

    public void TogglePause()
    {
        pause = !pause;
        if (pauseGO != null)
        {
            pauseGO.SetActive(pause); 
        }
        Time.timeScale = pause ? 0 : 1;
    }

    public void Restart()
    {
        this.Death();
    }
}
