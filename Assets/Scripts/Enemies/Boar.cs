using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Boar : Enemy
{


    public Tilemap brick;
    public Tilemap trap;
    public float walkSpeed = 1.0f;
    public float waitingTime = 1.0f;
    public float attackWaitingTime = 0.5f;
    public float dashSpeed = 15.0f;
    private bool waitBeforeMove = false;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brick = LevelSystem.GetInstance().BlocksTiles;
        trap = LevelSystem.GetInstance().TrapsTiles;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && !isAttacking)
        {
            isAttacking = CheckIfAttack();
            if (isAttacking)
            {
                StartCoroutine(WaitAndAttack());
            }
            else if (!waitBeforeMove)
            {
                Move();
            }
        }
    }

    public void Move()
    {
        Vector3Int voidPos = brick.WorldToCell(gameObject.transform.position - new Vector3(0, 0.5f, 0));

        RaycastHit2D hit = SendRaycast();

        float distance = 100.0f;
        if (hit)
        {
            if (!hit.collider.CompareTag("Player"))
            {
                distance = hit.distance;
            }
        }
        voidPos.x += right ? 2 : -2;
        voidPos.y -= 1;
        if (brick.GetTile(voidPos) == null || distance < 0.5f)
        {
            StartCoroutine(WaitAndTurn());
        }
        rb.velocity = new Vector2(right ? walkSpeed : -walkSpeed, rb.velocity.y);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            actionSystem.Death();
        }
    }



    IEnumerator WaitAndTurn()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        waitBeforeMove = true;
        if (!isAttacking)
            yield return new WaitForSeconds(waitingTime / 2.0f);
        if (!isAttacking)
            Flip();
        if (!isAttacking)
            yield return new WaitForSeconds(waitingTime / 2.0f);
        waitBeforeMove = false;

    }

    IEnumerator WaitAndAttack()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        yield return new WaitForSeconds(attackWaitingTime);
        //DASH

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = right ? Vector2.right : Vector2.left;
        rigid.AddForce(new Vector2(dashSpeed * (right ? 1.0f : -1.0f), 0f), ForceMode2D.Impulse);
        bool exit = false;
        bool stopped = false;
        while (!exit)
        {
            RaycastHit2D hit = SendRaycast();
            if (hit)
            {
                if (hit.collider.CompareTag("Ground") && hit.distance < 0.5f)
                {
                    exit = true;
                    stopped = true;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
        isAttacking = false;

        if (stopped)
        {
            rigid.velocity = new Vector2(right ? 0.1f : -0.1f, 0f);
            StartCoroutine(WaitAndTurn());
        }


    }

    private RaycastHit2D SendRaycast()
    {
        return Physics2D.Raycast(transform.position + new Vector3(right ? 1.9f : -1.9f, 0.0f, 0.0f), right ? Vector2.right : Vector2.left, 100.0f);
    }

    public override bool CheckIfAttack()
    {
        if (canAttack)
        {
            RaycastHit2D hit = SendRaycast();

            if (hit)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override EnemyType GetEnemyType()
    {
        return EnemyType.Boar;
    }


}
