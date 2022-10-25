using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CardBaseball : Card
{
    public override bool DoAction(Player p, bool destroy = true)
    {
        p.StartCoroutine(p.attackZone.ShowWaitHide());
        if (p.attackZone.EnemyIn)
        {
            p.attackZone.Enemy.GetComponent<Enemy>().Death();
        }
        if (destroy)
            this.Destroy();
        return true;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Baseball;
    }
}
