using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonFunctions", menuName = "UI Entity/Button Functions Object", order = 1)]
public class ButtonFunctions : ScriptableObject
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenProjectBoard()
    {
        Application.OpenURL("https://mthompson84877.weebly.com/colony.html");
    }
}
