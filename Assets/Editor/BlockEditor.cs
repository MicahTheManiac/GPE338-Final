using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Block))]
public class BlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Block block = (Block)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Get Material"))
        {
            block.GetMaterial();
        }

        if (GUILayout.Button("Reset"))
        {
            block.Reset();
        }

        GUILayout.EndHorizontal();
    }
}
