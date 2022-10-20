using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public int levelStartId = 0;
    public GameObject levelsContainer;
    public GameObject mainCamera;
    public ActionSystem actions;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
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
}
