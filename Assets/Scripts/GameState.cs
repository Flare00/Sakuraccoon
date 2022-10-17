using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public TextMeshProUGUI deathCounter;

    public int Last_Unlocked_Level{get; set;}
    public int Number_Of_Death{get; set;}
    public double Time_Played_In_Total{get; set;}
    public List<Card.CardType> Unlocked_Cards{get; set;}
    public int Max_Score_Endless{get;set;}

    public GameState()
    {
        Last_Unlocked_Level = 0;
        Number_Of_Death = 0;
        Time_Played_In_Total = 0;
        Unlocked_Cards = new List<Card.CardType>();
        Max_Score_Endless = 0;
    }

    public void AddUnlockedCard(Card.CardType card){
        this.Unlocked_Cards.Add(card);
    }

    public void IncrementDeath(){
        this.Number_Of_Death++;
        deathCounter.text = "Death : " + this.Number_Of_Death;
    }

    public void addTime(double time){
        Time_Played_In_Total += time;
    }

    private void Update()
    {
        addTime(Time.deltaTime);
    }
}
