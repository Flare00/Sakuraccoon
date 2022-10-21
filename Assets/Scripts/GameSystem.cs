using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour, GameStateListener
{

    public int levelStartId = 0;
    public GameObject levelsContainer;
    public GameObject mainCamera;
    public ActionSystem actions;

    //Affichage
    public TextMeshProUGUI deathCounter;

    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        GameState.GetInstance().AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            first = false;
            LateStart();
        }
    }



    private void LateStart()
    {
        LevelSystem.GetInstance().Camera = mainCamera;
        LevelSystem.GetInstance().Actions = actions;
        LevelSystem.GetInstance().FillLevels(levelsContainer);
        LevelSystem.GetInstance().StartLevel(levelStartId);
    }

    void GameStateListener.DeathIncrease()
    {
        deathCounter.text = "Death : " + GameState.GetInstance().Number_Of_Death;
    }
}