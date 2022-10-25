using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI;

public class CardCasseNoisette: Card
{    public float speed = 15.0f;

    public CardCasseNoisette()
    {
    }

    public override bool DoAction(Player p,bool destroy = true){
        Vector3 originalPos = p.transform.localPosition;
        GameObject projectile = GameObject.Instantiate(Resources.Load("Prefabs/Projectile", typeof(GameObject))) as GameObject;
        projectile.GetComponent<Projectile>().SetData(p.gameObject);
        projectile.transform.localPosition = originalPos + new Vector3(0.5f,0,0);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(p.direction >= 0 ? speed : -speed, 0);
        p.projectiles.Add(projectile);
        if (destroy)
            Destroy();
        return true;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.CasseNoisette;
    }
}
