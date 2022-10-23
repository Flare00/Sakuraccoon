using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameSystem : MonoBehaviour, GameStateListener
{

    public int levelStartId = 0;
    public GameObject levelsContainer;
    public GameObject Cameras;
    public GameObject MainCamera;
    public ActionSystem actions;

    public Tilemap blocks;
    public Tilemap traps;

    //Affichage
    public TextMeshProUGUI deathCounter;

    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        GameState.GetInstance().AddListener(this);
        LevelSystem.GetInstance().BlocksTiles = blocks;
        LevelSystem.GetInstance().TrapsTiles = traps;
        MainCamera.transform.localPosition = Vector3.zero;
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
        LevelSystem.GetInstance().Camera = Cameras;
        LevelSystem.GetInstance().Actions = actions;
        LevelSystem.GetInstance().FillLevels(levelsContainer);
        LevelSystem.GetInstance().StartLevel(levelStartId);
    }

    void GameStateListener.DeathIncrease()
    {
        deathCounter.text = "Death : " + GameState.GetInstance().Number_Of_Death;
    }
}
