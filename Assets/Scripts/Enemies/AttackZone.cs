using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public float showingTime = 0.2f;
    public bool IsPlayer = false;
    public bool EnemyIn = false;
    public GameObject Enemy = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsPlayer && collision.CompareTag("Player"))
        {
            EnemyIn = true;
            Enemy = collision.gameObject;
        } else if (IsPlayer && collision.CompareTag("Enemy"))
        {
            EnemyIn = true;
            Enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsPlayer && collision.CompareTag("Player"))
        {
            EnemyIn = true;
            Enemy = collision.gameObject;
        }
        else if (IsPlayer && collision.CompareTag("Enemy"))
        {
            EnemyIn = true;
            Enemy = collision.gameObject;
        }
    }

    public IEnumerator ShowWaitHide()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(showingTime);
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.0f);

    }
}
