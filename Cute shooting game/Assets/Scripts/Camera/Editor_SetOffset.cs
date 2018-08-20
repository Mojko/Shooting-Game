using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class Editor_SetOffset : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CameraFollow offset = (CameraFollow) target;
        if (GUILayout.Button("Set Offset"))
        {
           offset.SetOffset();
        }
    }
}