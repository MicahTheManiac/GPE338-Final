using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is our namespace
namespace GPE338
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
}
