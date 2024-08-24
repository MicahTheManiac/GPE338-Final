using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelParkour;

public abstract class Trigger : MonoBehaviour
{
    public HideMeshRenderer hmr = new HideMeshRenderer();

    // Start Method
    public abstract void Start();

    // Collision Detection
    public abstract void OnTriggerEnter(Collider other);

    
}
