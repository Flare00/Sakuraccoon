using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.DebugUI;

public class CardClimb: Card
{
    private Tilemap brick;

    public float speed = 15.0f;

    public CardClimb()
    {
        this.brick = LevelSystem.GetInstance().BlocksTiles;
    }

    public override bool DoAction(Player p,bool destroy = true){
        

        return true;
    }

    public override Card.CardType GetCardType()
    {
        return Card.CardType.Climb;
    }
}
