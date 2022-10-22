using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        None,
        Boar,
        Bear,
        Panda
    }

    protected bool isPlaying = true;
    protected bool right = true;
    public bool canAttack = true;
    public bool isAttacking = false;
    public ActionSystem actionSystem;

    public void Death()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    public void Stop()
    {
        Death();
    }

    public void Flip()
    {
        right = !right;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public abstract EnemyType GetEnemyType();

    public abstract bool CheckIfAttack();

    public static Enemy GenerateEnemyByType(EnemyType type, Transform parent, Vector2 position, bool right, ActionSystem actionSystem)
    {
        Enemy res = null;
        string enemyPrefabName = "";
        switch (type)
        {
            case EnemyType.Boar:
                enemyPrefabName = "Boar";
                break;
            case EnemyType.Bear:
                enemyPrefabName = "Bear";
                break;
            case EnemyType.Panda:
                //enemyPrefabName = "Panda"; //Panda not done yet
                break;
        }

        if(enemyPrefabName.Length > 0)
        {
            GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/Enemies/" + enemyPrefabName, typeof(GameObject))) as GameObject;
            res = go.GetComponent<Enemy>();
            if (!right)
            {
                res.Flip();
            }
            go.transform.position = new Vector3(position.x, position.y, 0);
            go.transform.SetParent(parent, false);
            res.actionSystem = actionSystem;
        }

        return res;
    }

    public IEnumerator WaitAndDeath()
    {
        yield return new WaitForSeconds(1.0f);
        Death();
    }
}
