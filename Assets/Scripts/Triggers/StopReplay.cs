using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopReplay : Trigger
{
    public bool idDiamondBlock = false;

    // Start is called before the first frame update
    public override void Start()
    {
        if (!idDiamondBlock)
        {
            hmr.Hide(gameObject);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        // Get our Replay Component
        Replay replay = other.GetComponent<Replay>();

        // If Replay is not null
        if (replay != null)
        {
            replay.ReplayStartRecording(false);
        }
    }
}
