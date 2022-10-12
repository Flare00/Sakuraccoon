using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public int Last_Unlocked_Level{get; set;}
    public int Number_Of_Death{get; set;}
    public double Time_Played_In_Total{get; set;}
    public List<Card.CardType> Unlocked_Cards{get; set;}
    public int Max_Score_Endless{get;set;}

    public void AddUnlockedCard(Card.CardType card){
        this.Unlocked_Cards.Add(card);
    }

    public void IncrementDeath(){
        this.Number_Of_Death++;
    }

    public void addTime(double time){
        Time_Played_In_Total += time;
    }
}
