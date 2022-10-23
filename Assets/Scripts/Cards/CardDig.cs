using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI;

public class CardDig : Card
{
    private Tilemap brick;
    public CardDig()
    {
        this.brick = LevelSystem.GetInstance().BlocksTiles;
    }
    public override bool DoAction(Player p,bool destroy = true){
        Vector3 originalPos = p.transform.localPosition - new Vector3(0,0.5f,0);
        Vector3Int pos = brick.WorldToCell(originalPos);
        pos.y--;
        TileBase b = brick.GetTile(pos);
        if (b != null)
        {
            TileBase tmp = null;
            do
            {
                pos.y--;
                tmp = brick.GetTile(pos);
                if(tmp == null)
                {
                    pos.y--;
                    tmp = brick.GetTile(pos);
                }
            } while (tmp != null);
            pos.y++;
            p.transform.position = new Vector3(originalPos.x, brick.CellToWorld(pos).y - 0.1f, originalPos.z);
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
