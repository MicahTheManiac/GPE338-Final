using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Trigger
{
    // Start is called before the first frame update
    public override void Start()
    {
        hmr.Hide(gameObject);
    }

    public override void OnTriggerEnter(Collider other)
    {
        // Get our Replay Component
        PlayerMovement playerMove = other.GetComponent<PlayerMovement>();

        // If Replay is not null
        if (playerMove != null)
        {
            playerMove.startingPosition = transform.position;
            Debug.Log($"Saved new Starting Position: {playerMove.startingPosition}");
        }
    }
}
