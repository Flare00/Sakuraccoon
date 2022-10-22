using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    public bool isPanda = false;

    void Update()
    {
        if (isPlaying)
        {
            isAttacking = CheckIfAttack();
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
        return false;
    }
    public override EnemyType GetEnemyType()
    {
        return isPanda ? EnemyType.Panda : EnemyType.Bear;
    }
}
