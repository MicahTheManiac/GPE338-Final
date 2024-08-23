using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayReplay : Trigger
{
    public bool isEndGoal = true;
    public Transform viewPoint;

    private LevelManager _levelManager;

    // Start is called before the first frame update
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
        PlayerMovement playerMove = other.GetComponent<PlayerMovement>();
        Replay replay = other.GetComponent<Replay>();

        // Only Disable Movement & Set Pos
        if (playerMove != null)
        {
            playerMove.enabled = false;
            playerMove.transform.position = viewPoint.position;
            playerMove.transform.rotation = viewPoint.rotation;
        }

        // Play Replay
        // If Replay is not null
        if (replay != null)
        {
            // Store Replay Length
            float sec = replay.ReplayGetSeconds();

            // Start Playback
            replay.ReplayPlayback(true);

            // Invoke Load
            Invoke("LoadNextScene", sec);

        }
    }

    private void LoadNextScene()
    {
        if (_levelManager != null)
        {
            _levelManager.LoadNextScene();
            Debug.Log("Loading...");
        }
    }
}
