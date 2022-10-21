using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class LevelSystem
{
    private static LevelSystem instance;

    public static LevelSystem GetInstance()
    {
        if (instance is null)
        {
            instance = new LevelSystem();
        }
        return instance;
    }

    private List<Level> levels;
    private Level currentLevel = null;
    private GameObject camera;
    private ActionSystem actions;

    public LevelSystem()
    {
        levels = new List<Level>();
    }

    public void StartLevel(int id)
    {
        Level find = null;
        for(int i = 0; i < levels.Count && find == null; i++)
        {
            if (levels[i].idLevel == id)
            {
                find = levels[i];
            }
        }


        StartLevel(find);
    }

    public void StartLevel(Level level)
    {
        if(level == null && levels.Count > 0)
        {
            level = levels[0];
        } 
        currentLevel = level;

        if (currentLevel != null)
        {
            if (camera != null)
            {

                camera.transform.position = new Vector3(currentLevel.transform.position.x, currentLevel.transform.position.y -1.0f, camera.transform.position.z) ;
            }
            currentLevel.StartLevel();
            if(GameState.GetInstance().Last_Unlocked_Level < currentLevel.idLevel)
            {
                GameState.GetInstance().Last_Unlocked_Level = currentLevel.idLevel;
            }
        }
    }

    public void ChangeLevel(Level nextLevel)
    {
        StopLevel();
        GameState.GetInstance().ChangeLevel(nextLevel.idLevel);
        StartLevel(nextLevel);
    }

    public void StopLevel()
    {
        Debug.Log("Actions : " + actions);
        actions.StopPlayer();
        if (currentLevel != null)
        {
            currentLevel.StopLevel();
        }
    }

    public void RestartLevel()
    {
        StopLevel();
        StartLevel(currentLevel);
    }


    public Level CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    public GameObject Camera 
    {
        set { camera = value; }
    }

    public ActionSystem Actions
    {
        set { actions = value; }
    }

    public void FillLevels(GameObject levelsParent)
    {
        levels.Clear();
        Level[] levelsList = levelsParent.GetComponentsInChildren<Level>();

        for(int i = 0, max = levelsList.Length; i < max; i++)
        {
            levels.Add(levelsList[i]);
        }
    }


}
