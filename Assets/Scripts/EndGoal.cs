using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    private LevelManager _levelManager;

    private void Start()
    {
        if (LevelManager.instance != null)
        {
            _levelManager = LevelManager.instance;
        }
    }

    // Collision Detection
    public void OnTriggerEnter(Collider other)
    {
        // Assume an Object with PlayerMovement is the Player
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            _levelManager.LoadNextScene();
        }
    }
}
