using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttackZone : MonoBehaviour
{
    public float showingTime = 0.2f;
    public bool PlayerIn = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIn = false;
        }
    }

    public IEnumerator ShowWaitHide()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(showingTime);
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.0f);

    }
}
