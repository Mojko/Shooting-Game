using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class Editor_SetCameraOffset : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CameraFollow camera = (CameraFollow) target;
        if (GUILayout.Button("Set Offset"))
        {
           camera.SetOffset(camera.transform.position);
        }
    }
}