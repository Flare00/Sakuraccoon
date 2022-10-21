using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState
{
    private static GameState instance;

    public static GameState GetInstance()
    {
        if (instance == null)
        {
            instance = new GameState();
        }
        return instance;
    }

    private List<GameStateListener> listeners;

    public int Last_Unlocked_Level{get; set;}
    public int Number_Of_Death{get; set;}
    public double Time_Played_In_Total{get; set;}
    public List<Card.CardType> Unlocked_Cards{get; set;}
    public int Max_Score_Endless{get;set;}

    public GameState()
    {
        listeners = new List<GameStateListener>();
        Unlocked_Cards = new List<Card.CardType>();

    }

    public void AddUnlockedCard(Card.CardType card){
        this.Unlocked_Cards.Add(card);
        SaveGameStates();
    }

    public void IncrementDeath(){
        this.Number_Of_Death++;
        for(int i = 0, max = listeners.Count; i < max; i++)
        {
            listeners[i].DeathIncrease();
        }
        SaveGameStates();
    }

    public void ChangeLevel(int level)
    {
        if(Last_Unlocked_Level < level)
        {
            this.Last_Unlocked_Level = level;
            SaveGameStates();
        }
    }

    public void addTime(double time){
        Time_Played_In_Total += time;
    }

    private void Update()
    {
        addTime(Time.deltaTime);
    }

    public void AddListener(GameStateListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameStateListener listener)
    {
        listeners.Remove(listener);
    }

    public static void LoadGameStates()
    {
        GameState gs = GameState.GetInstance();
        gs.Last_Unlocked_Level = PlayerPrefs.GetInt("Last_Unlocked_Level", 0);
        gs.Number_Of_Death = PlayerPrefs.GetInt("Number_Of_Death", 0);
        gs.Time_Played_In_Total = Convert.ToDouble(PlayerPrefs.GetString("Time_Played_In_Total", "0"));
        gs.Max_Score_Endless = PlayerPrefs.GetInt("Max_Score_Endless", 0);
        string uCards = PlayerPrefs.GetString("Unlocked_Cards", "");
        string[] splitted = uCards.Split('\u002C');
        gs.Unlocked_Cards.Clear();
        foreach (string s in splitted)
        {
            Card.CardType tmp = Card.GetCardTypeByString(s);
            if(tmp != Card.CardType.None)
            {
                gs.Unlocked_Cards.Add(tmp);
            }
        }
    }

    public static void SaveGameStates()
    {
        GameState gs = GameState.GetInstance();
        PlayerPrefs.SetInt("Last_Unlocked_Level", gs.Last_Unlocked_Level);
        PlayerPrefs.SetInt("Number_Of_Death", gs.Number_Of_Death);
        PlayerPrefs.SetString("Time_Played_In_Total", "" + gs.Time_Played_In_Total);
        PlayerPrefs.SetInt("Max_Score_Endless", gs.Max_Score_Endless);
        string uCards = "";
        for(int i = 0, max = gs.Unlocked_Cards.Count; i < max; i++)
        {
            uCards += gs.Unlocked_Cards[i].ToString();
            if (i < max - 1)
            {
                uCards += ",";
            }
        }
        PlayerPrefs.SetString("Unlocked_Cards", uCards);
        PlayerPrefs.Save();
    }
}
