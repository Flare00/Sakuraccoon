using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    public bool isPanda = false;
    public bool playerInAttackBound;
    public BearAttackZone attackZone;
    public float attackWaitingTime = 1.0f;
    private void Update()
    {
        if (isPlaying && !isAttacking)
        {
            isAttacking = CheckIfAttack();
            if (isAttacking)
            {
                StartCoroutine(WaitAndAttack());
            }
        }
    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            actionSystem.Death();
        }
    }

    public override bool CheckIfAttack()
    {
        return canAttack ? attackZone.PlayerIn : false;
    }
    public override EnemyType GetEnemyType()
    {
        return isPanda ? EnemyType.Panda : EnemyType.Bear;
    }

    IEnumerator WaitAndAttack()
    {
        yield return new WaitForSeconds(attackWaitingTime-0.2f);
        attackZone.StartCoroutine(attackZone.ShowWaitHide());
        yield return new WaitForSeconds(0.2f);

        if (attackZone.PlayerIn)
        {
            actionSystem.Death();
        }
        isAttacking = false;

    }
}
