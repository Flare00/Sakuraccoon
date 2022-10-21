using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI;

public class CardDig : Card
{
    private Tilemap brick;
    public CardDig(Tilemap brick)
    {
        this.brick = brick;
    }
    public override bool DoAction(Player p,bool destroy = true){
        Vector3Int pos = brick.WorldToCell(p.transform.localPosition);
        pos.y -= 1;
        TileBase b = brick.GetTile(pos);
        if (b != null)
        {
            TileBase tmp = null;
            do
            {
                pos.y -= 1;
                tmp = brick.GetTile(pos);
                if(tmp == null)
                {
                    pos.y -= 1;
                    tmp = brick.GetTile(pos);
                }
            } while (tmp != null);

            p.transform.position = brick.CellToWorld(pos);
            if (destroy)
                Destroy();
            return true;
        }
        return false;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Dig;
    }
}
