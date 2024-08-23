using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* DEPRECIATED */

public class EndGoal : Trigger
{
    private LevelManager _levelManager;

    public override void Start()
    {
        if (LevelManager.instance != null)
        {
            _levelManager = LevelManager.instance;
        }
    }

    // Collision Detection
    public override void OnTriggerEnter(Collider other)
    {
        // Assume an Object with PlayerMovement is the Player
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null && _levelManager != null)
        {
            _levelManager.LoadNextScene();
        }
    }
}

/* DEPRECIATED */
