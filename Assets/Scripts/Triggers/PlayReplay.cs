using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayReplay : Trigger
{
    public bool isEndGoal = true;
    public Transform viewPoint;

    private LevelManager _levelManager;
    private bool _inReplay = false;

    // Start is called before the first frame update
    public override void Start()
    {
        if (LevelManager.instance != null)
        {
            _levelManager = LevelManager.instance;
        }
    }

    // Update Method to Skip Replay
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _inReplay)
        {
            LoadNextScene();
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
            // Set that we are in Replay
            _inReplay = true;

            // Store Replay Length
            float sec = replay.ReplayGetSeconds() + 3f;

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
