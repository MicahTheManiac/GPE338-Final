using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelReference", menuName = "UI Entity/Level Reference", order = 1)]
public class LevelReference : ScriptableObject
{
    public string levelName;

    public void LoadLevel()
    {
        if (LevelManager.instance != null)
        {
            LevelManager levelManager = LevelManager.instance;
            levelManager.LoadScene(levelName);
        }
    }
}
