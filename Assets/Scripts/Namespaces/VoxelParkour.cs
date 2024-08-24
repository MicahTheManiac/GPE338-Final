using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is our namespace
namespace VoxelParkour
{
    // A class for hinding a MeshRenderer
    public class HideMeshRenderer
    {
        public void Hide(GameObject go)
        {
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.enabled = false;
        }
    }

    // Class for Level Save Data
    public class LevelSavaData
    {
        public int furthestLevel;
    }

    // Class for Options Save Data
    public class OptionsSaveData
    {
        public float mouseSensitivity;
    }
}
